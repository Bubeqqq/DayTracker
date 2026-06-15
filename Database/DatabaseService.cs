using DayTracker.Database.Datatypes;
using DayTracker.LoginServices;
using HashidsNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DayTracker.Database
{
    internal class DatabaseService : DbContext, IDatabaseService
    {
        DbSet<User> Users { get; set; }
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<CalendarEvent> CalendarEvents { get; set; }
        DbSet<Sleep> Sleeps { get; set; }
        DbSet<Permission> Permissions { get; set; }

        public int CurrentCalendarID { get; set; } = -1;

        private readonly SemaphoreSlim _dbLock = new SemaphoreSlim(1, 1);

        private ILoginService _loginService;

        private readonly IConfigurationRoot _configuration;

        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Resources/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _ = Task.Run(() => StartListeningForChangesAsync());
        }


        public event Action<string, int> OnEntityChanged;



        //

        /*private async Task StartListeningForChangesAsync()
        {
            while (true)
            {
                try
                {
                    string baseString = _configuration.GetConnectionString("NeonDatabase");
                    string listenString = $"{baseString};Pooling=false;KeepAlive=30;";

                    await using var conn = new NpgsqlConnection(listenString);
                    await conn.OpenAsync();

                    conn.Notification += (o, e) =>
                    {
                        string[] parts = e.Payload.Split('_');

                        if (parts.Length >= 2)
                        {
                            string tableName = parts[0];
                            string operation = parts[1];

                            string extractedId = parts.Length == 3 ? parts[2] : null;

                            var mainForm = Application.OpenForms[0];

                            if (mainForm != null && mainForm.IsHandleCreated)
                            {
                                mainForm.Invoke(new Action(() =>
                                {
                                    switch (tableName)
                                    {
                                        case "CalendarEvents":
                                            Console.WriteLine($"[KALENDARZ/UPRAWNIENIA] Tabela: {tableName}, Operacja: {operation}, CalendarId: {extractedId}");
                                            int idCal = int.Parse(extractedId);
                                            if (idCal == CurrentCalendarID)
                                            {
                                                OnEntityChanged?.Invoke(nameof(CalendarEvent), idCal);
                                            }
                                            break;
                                        case "Permissions":
                                            Console.WriteLine($"[KALENDARZ/UPRAWNIENIA] Tabela: {tableName}, Operacja: {operation}, CalendarId: {extractedId}");
                                            int idPer = int.Parse(extractedId);
                                            if (idPer == CurrentCalendarID)
                                            {
                                                OnEntityChanged?.Invoke(nameof(Permission), idPer);
                                            }
                                            break;

                                        case "Sleeps":
                                            Console.WriteLine($"[SEN] Tabela: {tableName}, Operacja: {operation}, UserId: {extractedId}");
                                            int idSlee = int.Parse(extractedId);
                                            if (_loginService != null && _loginService.GetUser() != null)
                                                if (idSlee == _loginService.GetUser().Id)
                                                {
                                                    OnEntityChanged?.Invoke(nameof(Sleep), idSlee);
                                                }
                                            break;

                                        case "Users":
                                            Console.WriteLine($"[UŻYTKOWNICY] Wykryto zmianę. Operacja: {operation}");
                                            OnEntityChanged?.Invoke(nameof(User), 0);
                                            break;

                                        case "TodoItems":
                                            Console.WriteLine($"[ZADANIA] Wykryto zmianę. Operacja: {operation}");
                                            OnEntityChanged?.Invoke(nameof(TodoItem), 0);
                                            break;
                                    }
                                }));
                            }
                        }
                    };

                    await using var cmd = new NpgsqlCommand("LISTEN app_changes_channel;", conn);
                    await cmd.ExecuteNonQueryAsync();

                    Console.WriteLine("Nasłuchiwanie wszystkich 5 tabel uruchomione...");

                    while (true)
                    {
                        await conn.WaitAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd połączenia z Neon.tech: {ex.Message}. Ponowna próba za 5 sekund...");
                    await Task.Delay(5000);
                }
            }
        }*/

        private async Task StartListeningForChangesAsync()
        {
            while (true)
            {
                try
                {
                    string baseString = _configuration.GetConnectionString("NeonDatabase");

                    // DODANE: Tcp Keepalive=true - wymusza wysyłanie sygnałów podtrzymujących na poziomie karty sieciowej
                    string listenString = $"{baseString};Pooling=false;KeepAlive=10;Tcp Keepalive=true;";

                    await using var conn = new NpgsqlConnection(listenString);
                    await conn.OpenAsync();

                    conn.Notification += (o, e) =>
                    {
                        string[] parts = e.Payload.Split('_');

                        if (parts.Length >= 2)
                        {
                            string tableName = parts[0];
                            string operation = parts[1];

                            string extractedId = parts.Length == 3 ? parts[2] : null;

                            var mainForm = Application.OpenForms[0];

                            if (mainForm != null && mainForm.IsHandleCreated)
                            {
                                mainForm.Invoke(new Action(() =>
                                {
                                    switch (tableName)
                                    {
                                        case "CalendarEvents":
                                            Console.WriteLine($"[KALENDARZ/UPRAWNIENIA] Tabela: {tableName}, Operacja: {operation}, CalendarId: {extractedId}");
                                            int idCal = int.Parse(extractedId);
                                            if (idCal == CurrentCalendarID)
                                            {
                                                OnEntityChanged?.Invoke(nameof(CalendarEvent), idCal);
                                            }
                                            break;
                                        case "Permissions":
                                            Console.WriteLine($"[KALENDARZ/UPRAWNIENIA] Tabela: {tableName}, Operacja: {operation}, CalendarId: {extractedId}");
                                            int idPer = int.Parse(extractedId);
                                            if (idPer == CurrentCalendarID)
                                            {
                                                OnEntityChanged?.Invoke(nameof(Permission), idPer);
                                            }
                                            break;

                                        case "Sleeps":
                                            Console.WriteLine($"[SEN] Tabela: {tableName}, Operacja: {operation}, UserId: {extractedId}");
                                            int idSlee = int.Parse(extractedId);
                                            if (_loginService != null && _loginService.GetUser() != null)
                                                if (idSlee == _loginService.GetUser().Id)
                                                {
                                                    OnEntityChanged?.Invoke(nameof(Sleep), idSlee);
                                                }
                                            break;

                                        case "Users":
                                            Console.WriteLine($"[UŻYTKOWNICY] Wykryto zmianę. Operacja: {operation}");
                                            OnEntityChanged?.Invoke(nameof(User), 0);
                                            break;

                                        case "TodoItems":
                                            Console.WriteLine($"[ZADANIA] Wykryto zmianę. Operacja: {operation}");
                                            OnEntityChanged?.Invoke(nameof(TodoItem), 0);
                                            break;
                                    }
                                }));
                            }
                        }
                    };

                    await using var cmd = new NpgsqlCommand("LISTEN app_changes_channel;", conn);
                    await cmd.ExecuteNonQueryAsync();

                    Console.WriteLine("Nasłuchiwanie uruchomione...");

                    // NOWA WEWNĘTRZNA PĘTLA Z "WATCHDOGIEM"
                    while (true)
                    {
                        // Ustawiamy limit czekania na 45 sekund
                        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(45));

                        try
                        {
                            // Czekamy na powiadomienie, ale jeśli minie 45s, wywoła się wyjątek OperationCanceledException
                            await conn.WaitAsync(cts.Token);
                        }
                        catch (OperationCanceledException)
                        {
                            // Cisza w eterze od 45 sekund. Sprawdzamy, czy połączenie nadal fizycznie istnieje.
                            // Wysyłamy najprostsze możliwe zapytanie, które nic nie waży.
                            await using var pingCmd = new NpgsqlCommand("SELECT 1;", conn);
                            await pingCmd.ExecuteNonQueryAsync();

                            // Jeśli połączenie działa, pętla zawróci i znów zacznie nasłuchiwać na kolejne 45s.
                            // Jeśli połączenie zostało po cichu zerwane przez router, ExecuteNonQueryAsync wyrzuci błąd
                            // i wyrzuci nas do GŁÓWNEGO bloku catch na samym dole, który nawiąże połączenie od nowa!
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Tutaj teraz wpadnie błąd, jeśli "Watchdog" wykryje zerwanie połączenia
                    Console.WriteLine($"Błąd/Zerwanie nasłuchiwania: {ex.Message}. Restart za 5s...");
                    await Task.Delay(5000);
                }
            }
        }

        //

        public async Task<T> AddAsync<T>(T record) where T : class, ICalendarRecord
        {
            if (record == null)
            {
                return null;
            }

            await _dbLock.WaitAsync();
            try
            {
                if (record is CalendarEvent calendarRecord)
                {
                    calendarRecord.CalendarId = CurrentCalendarID;
                    calendarRecord.Id = 0;
                }
                else if (record is Sleep sleepRecord)
                {
                    sleepRecord.Id = 0;
                }
                else if (record is Permission permissionRecord)
                {
                    permissionRecord.Id = 0;
                }
                else if (record is TodoItem todoRecord)
                {
                    todoRecord.Id = 0;
                }

                await Set<T>().AddAsync(record);
                await SaveChangesAsync();

                return record;
            }
            finally
            {
                _dbLock.Release();
            }
        }

        private int Encode(int originalId)
        {
            unchecked
            {
                int scrambled = originalId * 7727;
                return scrambled ^ 987654321;
            }
        }

        public async Task AddUserAsync(User record)
        {
            await _dbLock.WaitAsync();
            try
            {
                record.Id = 0;
                await Users.AddAsync(record);
                await SaveChangesAsync();
                record.CalendarId = Encode(record.Id);
                Hashids hashids = new Hashids(_configuration.GetConnectionString("InvitationCode"), 6);
                record.invitationCode = hashids.Encode(record.CalendarId);
                await SaveChangesAsync();
            }
            finally
            {
                _dbLock.Release();
            }
        }

        public async Task<List<User>> GetUsersAsync(Expression<Func<User, bool>> predicate)
        {
            await _dbLock.WaitAsync();
            try
            {
                return await Users.Where(predicate).ToListAsync();
            }
            finally
            {
                _dbLock.Release();
            }
        }

        public async Task EnsureCreated()
        {
            await _dbLock.WaitAsync();
            try
            {
                await Database.EnsureCreatedAsync();
            }
            finally
            {
                _dbLock.Release();
            }
        }

        public async Task<List<T>> GetType<T>() where T : class, ICalendarRecord
        {
            await _dbLock.WaitAsync();
            try
            {
                this.ChangeTracker.Clear();

                return typeof(T) switch
                {
                    Type t when t == typeof(TodoItem) => await TodoItems.ToListAsync() as List<T>,
                    Type t when t == typeof(CalendarEvent) => await CalendarEvents.Include(e => e.Todo).Where(e => e.CalendarId == CurrentCalendarID).ToListAsync() as List<T>,
                    Type t when t == typeof(Sleep) => await Sleeps.ToListAsync() as List<T>,
                    Type t when t == typeof(Permission) => await Permissions.ToListAsync() as List<T>,
                    _ => throw new InvalidOperationException($"Type {typeof(T).Name} is not supported.")
                };
            }
            finally
            {
                _dbLock.Release();
            }
        }

        public async Task<List<T>> GetType<T>(Expression<Func<T, bool>> predicate) where T : class, ICalendarRecord
        {
            await _dbLock.WaitAsync();
            try
            {
                this.ChangeTracker.Clear();

                return typeof(T) switch
                {
                    Type t when t == typeof(TodoItem) => await TodoItems.Where(predicate as Expression<Func<TodoItem, bool>>).ToListAsync() as List<T>,
                    Type t when t == typeof(CalendarEvent) => await CalendarEvents.Include(e => e.Todo).Where(predicate as Expression<Func<CalendarEvent, bool>>).Where(e => e.CalendarId == CurrentCalendarID).ToListAsync() as List<T>,
                    Type t when t == typeof(Sleep) => await Sleeps.Where(predicate as Expression<Func<Sleep, bool>>).ToListAsync() as List<T>,
                    Type t when t == typeof(Permission) => await Permissions.Where(predicate as Expression<Func<Permission, bool>>).ToListAsync() as List<T>,
                    _ => throw new InvalidOperationException($"Type {typeof(T).Name} is not supported.")
                };
            }
            finally
            {
                _dbLock.Release();
            }
        }

        public async Task<PermissionType> LoadUserPermissions(int UserID, int CalendarID)
        {
            await _dbLock.WaitAsync();
            try
            {
                List<Permission> permissions = await Permissions.Where(p => p.UserId == UserID && p.CalendarId == CalendarID).ToListAsync();

                if (permissions.Count == 0)
                {
                    return PermissionType.Blocked;
                }

                if (permissions.Count > 1)
                {
                    throw new InvalidOperationException($"User with ID {UserID} has multiple permissions for calendar with ID {CalendarID}.");
                }

                return permissions[0].PermissionName;
            }
            finally
            {
                _dbLock.Release();
            }
        }

        /*public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is CalendarEvent calendarEvent)
                {
                    if (calendarEvent.CalendarId == CurrentCalendarID)
                    {
                        OnEntityChanged?.Invoke(nameof(CalendarEvent), entry.State);
                    }
                }
                else if (entry.Entity is Sleep sleep)
                {
                    if (_loginService != null)
                    {
                        if(_loginService.GetUser() != null)
                            if (_loginService.GetUser().Id == sleep.UserId)
                                OnEntityChanged?.Invoke(nameof(Sleep), entry.State);
                    }
                    else
                    {
                        OnEntityChanged?.Invoke(nameof(Sleep), entry.State);
                    }
                }
                else
                {
                    string tableName = entry.Entity.GetType().Name;
                    OnEntityChanged?.Invoke(tableName, entry.State);
                }
            }

            return result;
        }*/

        async Task IDatabaseService.RemoveByType<T>(int index)
        {
            await _dbLock.WaitAsync();
            try
            {
                var record = await Set<T>().FindAsync(index);

                if (record != null)
                {
                    Remove(record);
                    await SaveChangesAsync();
                }
            }
            finally
            {
                _dbLock.Release();
            }
        }

        async Task IDatabaseService.RemoveByType<T>(T record)
        {
            if (record == null)
            {
                return;
            }

            await _dbLock.WaitAsync();
            try
            {
                Remove(record);
                await SaveChangesAsync();
            }
            finally
            {
                _dbLock.Release();
            }
        }

        async Task<T> IDatabaseService.UpdateByType<T>(int index, Action<T> update)
        {
            await _dbLock.WaitAsync();
            try
            {
                object? foundRecord = null;

                switch (typeof(T))
                {
                    case Type t when t == typeof(TodoItem):
                        foundRecord = await TodoItems.FindAsync(index);
                        break;
                    case Type t when t == typeof(CalendarEvent):
                        foundRecord = await CalendarEvents.FindAsync(index);
                        break;
                    case Type t when t == typeof(Sleep):
                        foundRecord = await Sleeps.FindAsync(index);
                        break;
                    case Type t when t == typeof(Permission):
                        foundRecord = await Permissions.FindAsync(index);
                        break;
                }

                if (foundRecord != null)
                {
                    update((T)foundRecord);
                    await SaveChangesAsync();
                    return (T)foundRecord;
                }

                throw new ArgumentNullException($"{index} not found.");
            }
            finally
            {
                _dbLock.Release();
            }
        }

        async Task<T> IDatabaseService.UpdateByType<T>(T record, Action<T> update)
        {
            if (record == null)
            {
                throw new ArgumentNullException($"{nameof(record)} cannot be null.");
            }

            await _dbLock.WaitAsync();
            try
            {
                update(record);
                Update(record);
                await SaveChangesAsync();
                return record;
            }
            finally
            {
                _dbLock.Release();
            }
        }

        public void AddLoginService(ILoginService loginService)
        {
            _loginService = loginService;
        }
    }
}