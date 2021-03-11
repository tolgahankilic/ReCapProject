using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "The car has been added to DB.";
        public static string CarDailyPriceInvalid = "Daily price must be higher than 0";
        public static string CarDeleted = "The car has been deleted to DB.";
        public static string CarListed = "Cars listed.";
        public static string CarDetails = "Cars details listed.";
        public static string CarsListedBrandId = "Cars listed by brand id";
        public static string CarsListedColorId = "Cars listed by color id";
        public static string CarUpdated = "The car has been updated to DB.";
        public static string GetErrorCarDetails = "Vehicle information not found!";

        public static string ColorAdded = "The color has been added to DB.";
        public static string ColorDeleted = "The color has been deleted to DB.";
        public static string ColorListed = "Colors listed.";
        public static string ColorUpdated = "The color has been updated to DB.";

        public static string BrandAdded = "The brand has been added to DB.";
        public static string BrandDeleted = "The brand has been deleted to DB.";
        public static string BrandListed = "Brands listed.";
        public static string BrandUpdated = "The brand has been updated to DB.";

        public static string CarAlreadyRented = "The car already rented";
        public static string RentalAdded = "The rental has been added to DB";
        public static string RentalListed = "Rentals listed";
        public static string RentalDetails = "Rental details listed";
        public static string RentalDeleted = "The rental has been deleted to DB.";
        public static string RentalUpdated = "The rental has been updated to DB.";

        public static string UserAdded = "The user has been added to DB.";
        public static string UserDeleted = "The user has been deleted to DB.";
        public static string UserListed = "Users listed.";
        public static string UserUpdated = "The user has been updated to DB.";
        public static string UserDetails = "User details listed";

        public static string CustomerAdded = "The customer has been added to DB.";
        public static string CustomerDeleted = "The customer has been deleted to DB.";
        public static string CustomerListed = "Customers listed.";
        public static string CustomerUpdated = "The customer has been updated to DB.";
        public static string CustomerDetails = "Customer details listed";

        public static string CarImageAdded = "The car images has been added to DB.";
        public static string CarImageDeleted = "The car images has been deleted to DB.";
        public static string CarImageUpdated = "The car images has been updated to DB.";
        public static string ImageAddingLimit = "You can add 5 photos";

        public static string AuthorizationDenied = "You are not authorized";
        public static string UserRegistered = "User registered";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Wrong password!";
        public static string SuccessfulLogin = "Signed in";
        public static string UserAlreadyExists = "User already exists";
        public static string AccessTokenCreated = "Access token created";
    }
}
