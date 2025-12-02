using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Users
{
    public static class UserErrors
    {
        // Identity-related errors
        public static readonly Error IdentityIdRequired = new("Account.IdentityIdRequired", "Identity ID cannot be empty");
        public static readonly Error IdentityIdAlreadySet = new("Account.IdentityIdAlreadySet", "Identity ID is already set");

        // Activation-related errors
        public static readonly Error CannotActivateDeletedAccount = new("Account.CannotActivateDeletedUser", "Cannot activate a deleted user");
        public static readonly Error CannotActivateWithoutIdentity = new("Account.CannotActivateWithoutIdentity", "Cannot activate account without identity");
        public static readonly Error ActivatorRequired = new("Account.ActivatorRequired", "Activator user ID must be specified");
        
        // Deactivation-related errors
        //public static readonly Error CannotDeactivateInactiveAccount = new("Account.CannotDeactivateInactiveAccount", "Cannot deactivate an inactive account");
        public static readonly Error DeactivatorRequired = new("User.DeactivatorRequired", "Deactivator user ID must be specified");

        // Delete-related errors
        public static readonly Error DeleterRequired = new("Account.DeleterRequired", "Deleter user ID must be specified");

        //Recover-related errors
        public static readonly Error RecovererRequired = new("User.RecovererRequired", "Recoverer user ID must be specified");

        // User-related errors
        public static readonly Error CannotUpdateDeletedUser = new("User.CannotUpdateDeletedUser", "Cannot update a deleted user");
        public static readonly Error FirstNameRequired = new("User.FirstNameRequired", "First name is required");
        public static readonly Error MidNameRequired = new("User.MidNameRequired", "Mid name is required");
        public static readonly Error LastNameRequired = new("User.LastNameRequired", "Last name is required");
        public static readonly Error PasswordRequired = new("User.PasswordRequired", "Password is required");
        public static readonly Error ModifierRequired = new("User.ModifierRequired", "Modifier user ID must be specified");
        
        //PhoneNumber-related errors
        public static readonly Error PhoneNumberRequired = new("User.PhoneNumberRequired", "Phone number is required");
        public static readonly Error InvalidPhoneNumberFormat = new("User.InvalidPhoneNumberFormat", "Phone number must contain 10-15 digits");
    }
}