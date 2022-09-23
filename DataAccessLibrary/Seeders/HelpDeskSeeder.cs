using DataAccessLibrary.Data;
using DataAccessLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.Seeders;

public class HelpDeskSeeder
{
    private readonly HelpDeskDbContext _dbcontext;

    public HelpDeskSeeder(HelpDeskDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public void Seed()
    {
        if (_dbcontext.Database.CanConnect())
        {
            var roles = SeedRoles();
            var buildings = SeedBuildings();
            var categories = SeedCategories();
            var devices = SeedDevices();
            var users = SeedUsers();
            var requests = SeedRequests();


            if (!_dbcontext.Roles.Any())
            {
                _dbcontext.Roles.AddRange(roles);
                _dbcontext.SaveChanges();
            }

            if (!_dbcontext.Buildings.Any())
            {
                _dbcontext.Buildings.AddRange(buildings);
                _dbcontext.SaveChanges();
            }

            if (!_dbcontext.Users.Any())
            {
                _dbcontext.Users.AddRange(users);
                _dbcontext.SaveChanges();
            }
            if (!_dbcontext.Devices.Any())
            {
                _dbcontext.Devices.AddRange(devices);
                _dbcontext.SaveChanges();
            }

            if (!_dbcontext.Categories.Any())
            {
                _dbcontext.Categories.AddRange(categories);
                _dbcontext.SaveChanges();
            }

            if (!_dbcontext.Requests.Any())
            {
                _dbcontext.Requests.AddRange(requests);
                _dbcontext.SaveChanges();
            }
        }
    }

    private IEnumerable<Role> SeedRoles()
    {
        var roles = new List<Role>
        {
            new()
            {
                Name = "Administrator",
                Description = "Główny administrator helpdesk."
            },
            new()
            {
                Name = "Helpdesk",
                Description = "Pracownik helpdesk."
            },
            new()
            {
                Name = "Telekomunikacja",
                Description = "Pracownik odpowiedzialny za węzeł telekomunikacyjny."
            },
            new()
            {
                Name = "Sieciowiec",
                Description = "Pracownik odpowiedzialny za działanie sieci."
            },
            new()
            {
                Name = "Pracownik Biurowy",
                Description = "Pracownik wykonujący prace biurowe."
            },

        };
        return roles;
    }

    private IEnumerable<Category> SeedCategories()
    {
        var categories = new List<Category>
        {
            new()
            {
                Name = "Komputery",
                Description = "Wszysto co związane z komputerami."
            },
            new()
            {
                Name = "Peryferia",
                Description = "Monitory, myszki, itp."
            },
            new()
            {
                Name = "Drukarki",
                Description = "Wszysto co związane z drukarkami."
            },
            new()
            {
                Name = "Software",
                Description = "Wszysto co związane z oprogramowanie."
            },
            new()
            {
                Name = "Inne",
                Description = "Problemy inne niz zwyczajne."
            },
        };
        return categories;
    }

    private IEnumerable<Building> SeedBuildings()
    {
        var buildings = new List<Building>
        {
            new()
            {
                Name = "A01",
                Description = "Budynek biurowy"
            },
            new()
            {
                Name = "A02",
                Description = "Budynek biurowy"
            },
            new()
            {
                Name = "B01",
                Description = "Budynek produkcyji meblościanek."
            },
            new()
            {
                Name = "B02",
                Description = "Budynek produkcji szafek."
            },
            new()
            {
                Name = "G01",
                Description = "Magazyn drewna."
            }
        };

        return buildings;
    }

    private IEnumerable<User> SeedUsers()
    {
        var users = new List<User>
        {
            new()
            {
                Login = "Admin-a",
                Password = "admin",
                Email = "admin@helpdesk.com",
                Name = "Administrator",
                sName = "Administratorowy",
                Phone = "111 111 111",
                RoleId = 1,
                BuildingId = 1
            },
            new()
            {
                Login = "Nowak-a",
                Password = "helpdesk2022",
                Email = "andrzejNowak@gmail.com",
                Name = "Andrzej",
                sName = "Nowak",
                Phone = "111 222 111",
                RoleId = 2,
                BuildingId = 1
            },
            new()
            {
                Login = "Milosz-j",
                Password = "helpdesk2022",
                Email = "jadwigaMilosz@gmail.com",
                Name = "Jadwiga",
                sName = "Miłosz",
                Phone = "111 121 333",
                RoleId = 5,
                BuildingId = 2
            },
            new()
            {
                Login = "krzemien-s",
                Password = "helpdesk2022",
                Email = "sylwesterKrzemien@gmail.com",
                Name = "Sylwester",
                sName = "Krzemień",
                Phone = "123 131 114",
                RoleId = 5,
                BuildingId = 3
            },
            new()
            {
                Login = "raczek-w",
                Password = "helpdesk2022",
                Email = "witoldRaczek@gmail.com",
                Name = "Witold",
                sName = "Raczek",
                Phone = "444 332 123",
                RoleId = 5,
                BuildingId = 1
            }
        };

        return users;
    }

    private IEnumerable<Device> SeedDevices()
    {
        var devices = new List<Device>
        {
            new()
            {
                Brand = "Lenovo",
                Model = "Thinkpad X1",
                Type = "Laptop",
                BuildingId = 1,
                UserId = 1
            },
            new()
            {
                Brand = "Asus",
                Model = "Zenbook S13",
                Type = "Laptop",
                BuildingId = 3,
                UserId = 2
            },
            new()
            {
                Brand = "HP",
                Model = "OfficeJet G122SEER",
                Type = "Drukarka",
                BuildingId = 2,
                UserId = 1
            },
            new()
            {
                Brand = "HP",
                Model = "Elitebook",
                Type = "Laptop",
                BuildingId = 1,
                UserId = 3
            },
            new()
            {
                Brand = "HP",
                Model = "OfficeJet G122SEER",
                Type = "Drukarka",
                BuildingId = 1,
                UserId = 1
            }
        };

        return devices;
    }

    private IEnumerable<Request> SeedRequests()
    {
        var requests = new List<Request>
        {
            new()
            {
                Title = "Problem z laptopem",
                Description = "Nie moge zalogować się do SAP Fiori",
                Status = "Zakonczone",
                Date = Convert.ToDateTime("11-11-2020"),
                CategoryId = 4,
                UserId = 2,
                DeviceId = 2,
                FixerId = 1,
                FixerOpinion = "Restart fiori"
            },
            new()
            {
                Title = "Problem z drzwiami",
                Description = "Nie moge przejść przez drzwi budynki A01",
                Status = "Zakonczone",
                Date = Convert.ToDateTime("11-09-2022"),
                CategoryId = 5,
                UserId = 2,
                DeviceId = 1,
                FixerId = 1,
                FixerOpinion = "zgłoszono do konserwatora"
            },
            new()
            {
                Title = "Problem z laptopem",
                Description = "Nie moge zalogować się do SAP Fiori",
                Status = "Zakonczone",
                Date = Convert.ToDateTime("12-09-2022"),
                CategoryId = 4,
                UserId = 2,
                DeviceId = 1,
                FixerId = 1,
                FixerOpinion = "Ponownie zainstalowano fiori"
            },
            new()
            {
                Title = "Teams nie działa",
                Description = "Nie moge zalogować się do ms teams. Pilnie proszę o pomoc",
                Status = "Nowe",
                Date = Convert.ToDateTime("13-09-2022"),
                CategoryId = 4,
                UserId = 3,
                DeviceId = 3,
                FixerId = 1,
                FixerOpinion = "Restart komputera"
            },
            new()
            {
                Title = "Drukarka nie działa",
                Description = "Nie moge wydrukować listy pracowników.",
                Status = "Zakonczone",
                Date = Convert.ToDateTime("13-09-2022"),
                CategoryId = 3,
                UserId = 3,
                DeviceId = 3,
                FixerId = 1,
                FixerOpinion = "Wymiana tonera"
            }

        };
            return requests;
    }
}