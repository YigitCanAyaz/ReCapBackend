using System;
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

        // Color Manager
        public static string ColorCreated = "Color created";
        public static string ColorUpdated = "Color updated";
        public static string ColorDeleted = "Color deleted";

        // OperationClaim Manager
        public static string OperationClaimCreated = "OperationClaim created";
        public static string OperationClaimUpdated = "OperationClaim updated";
        public static string OperationClaimDeleted = "OperationClaim deleted";

        // UserOperationClaim Manager
        public static string UserOperationClaimCreated = "UserOperationClaim created";
        public static string UserOperationClaimUpdated = "UserOperationClaim updated";
        public static string UserOperationClaimDeleted = "UserOperationClaim deleted";

        // Customer Manager
        public static string CustomerCreated = "Customer created";
        public static string CustomerUpdated = "Customer updated";
        public static string CustomerDeleted = "Customer deleted";

        // Model Manager
        public static string ModelCreated = "Model created";
        public static string ModelUpdated = "Model updated";
        public static string ModelDeleted = "Model deleted";

        // Rental Manager
        public static string RentalCreated = "Rental created";
        public static string RentalUpdated = "Rental updated";
        public static string RentalDeleted = "Rental deleted";

        // User Manager
        public static string UserCreated = "User created";

        public static string AccessTokenCreated = "Access token is created";

    }
}
