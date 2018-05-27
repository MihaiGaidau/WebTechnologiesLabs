# REPORT Laboratory nr 3,4
**Objective:**

* Connect with a database
* Add users

In laboratory work nr 3 I had to connect my app to a database, so I created a database of restaurants. the models pof my project are Restaurant
public class Restaurant
    {
        public int Id { get; set; }
        [Display(Name="Restaurant Name")]
//        [DataType(DataType.Password)]
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }

After this model, I've created the database the database,  the connection with it I've done with service "SqlRestaurantData", thats implements interface IRestarantData.
I've created the interface because, from the begining I had I InMemoryRestaurantData, that i used localy.

"SqlRestaurantData"

public class SqlRestaurantData:IRestaurantData
    {
        private WebApplication1DbContext _context;

        public SqlRestaurantData(WebApplication1DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
           return  _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var _myrest = new Restaurant()
            {
                Id = restaurant.Id,
                Cuisine = restaurant.Cuisine,
                Name = restaurant.Name
            };
            _context.Restaurants.Attach(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
            return restaurant;
        }
    }


Here I have a problem with the *Update* function, It doesn't work as it has. So, I have a problem with the Edit. The error is said that I din't create an *Id* for the edit element, but it has it own id, because I edit the selected user. I didn't know how to manage it.


In order to add users, i've created the IUserService interface. I've tried to add another table to the database, but, I has some problems, so I created UserService, thats create a dictionary that stores users localy. 

 public class UserService: IUserService
    {
        private IDictionary<string, (string PasswordHash, User User)> _users = new Dictionary<string, (string PasswordHash, User User)>();
        public UserService(IDictionary<string, string> users)
        {
            foreach (var user in users)
            {
                _users.Add(user.Key.ToLower(), (BCrypt.Net.BCrypt.HashPassword(user.Value), new User(user.Key)));
            }
            
        }
        public Task<bool> ValidateCredentials(string username, string password, out User user)
        {
            user = null;
            var key = username.ToLower();
            if (_users.ContainsKey(key))
            {
                var hash = _users[key].PasswordHash;
                if (BCrypt.Net.BCrypt.Verify(password, hash))
                {
                    user = _users[key].User;
                    return Task.FromResult(true);
                }
            }

            return Task.FromResult(false);
        }

        public Task<bool> AddUser(string username, string password)
        {
            if (_users.ContainsKey(username.ToLower()))
            {
                return Task.FromResult(false);
            }

            _users.Add(username.ToLower(), (BCrypt.Net.BCrypt.HashPassword(password), new User(username)));
            return Task.FromResult(true);
        }
    }

In order to mantaint the user secure, I used *bycrypt* to encrypt and decrypt passwords.

*_users.Add(username.ToLower(), (BCrypt.Net.BCrypt.HashPassword(password), new User(username)));*

In order to do the log in and sign up I created models for each.

public class SignUpModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
    }



As a user, you can view the restaurants and manage them only if you are logged in.

. A user can add restaurants. I wanted to create a list of restaurants for each user, but I didn't know to to do it.


 One of the feature of application is that is keeping sesion even if you close the application. 


I had some problems with styles, I don't know why, but it doesn't want to iport styles in another pages , only in main. the error is "CSS was ignored due to mime type mismatch" even if in source code it has a link to the style.

It was interesting working with ASP.NET MVC, and I 've learned a lot about arhitecture and how the web sites are done.


**References**

1.Presentation from WebTechnology courses. Antohi Ionel
2. [Wikipedia ASP.NET MVC](https://en.wikipedia.org/wiki/ASP.NET_MVC)
3. pluralsight.com