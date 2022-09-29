﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants.Messages
{
    public class Messages : IMessages
    {
        public const string CarImageNotExist = "Car Image Not Exists";
        public static string AuthorizationDenied = "Authorization Denied";

        // Auth Manager
        public static string UserRegistered = "User has been created";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password is wrong";
        public static string SuccessfulLogin = "Successful login";
        public static string UserAlreadyExists = "User already exists";

        // Brand Manager
        public static string BrandCreated = "Brand created";
        public static string BrandUpdated= "Brand updated";
        public static string BrandDeleted = "Brand deleted";

        // CarImage Manager
        public static string CarImageCreated = "Car Image created";
        public static string CarImageUpdated = "Car Image updated";
        public static string CarImageDeleted = "Car Image deleted";

        // Car Manager
        public static string CarCreated = "Car created";
        public static string CarUpdated = "Car updated";
        public static string CarDeleted = "Car deleted";

        public static string AccessTokenCreated = "Access token is created";

    }
}
