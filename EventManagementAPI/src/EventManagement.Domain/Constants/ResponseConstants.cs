using EventManagement.Domain.Models;

namespace EventManagement.Domain.Constants
{
    public static class ResponseConstants
    {
        public static readonly ResponseConstant SuccessfullyCreated = new(true, "Successfully created!");

        public static readonly ResponseConstant CreateFailed = new(false, "Create failed! Please try again.");

        public static readonly ResponseConstant SuccessfullyDeleted = new(true, "Successfully deleted!");

        public static readonly ResponseConstant DeleteFailed = new(false, "Delete failed! Please try again.");

        public static readonly ResponseConstant SuccessfullyUpdated = new(true, "Successfully updated!");

        public static readonly ResponseConstant UpdateFailed = new(false, "Update failed! Please try again.");

        public static readonly ResponseConstant LoginSuccessful = new(true, "Login successful!");

        public static readonly ResponseConstant EmailOrPasswordIncorrect = new(false, "Email or password is incorrect!");

        public static readonly ResponseConstant CurrentPasswordIncorrect = new(false, "The Current password is incorrect!");

        public static readonly ResponseConstant ExistsUserWithSameEmail = new(false, "A user with the same email address already exists!");

        public static readonly ResponseConstant ExistsCategoryWithSameName = new(false, "A category with the same name already exists!");

        public static readonly ResponseConstant ExistsLocationWithSameName = new(false, "A location with the same name already exists!");

        public static readonly ResponseConstant ReachedEventQuota = new(false, "The quota for the event has been reached!");

        public static readonly ResponseConstant SuccessfullyPurchased = new(true, "Successfully purchased!");
        
        public static readonly ResponseConstant PurchaseFailed = new(false, "Purchase failed! Please try again.");

        public static readonly ResponseConstant TicketValid = new(true, "The ticket number entered is valid!");

        public static readonly ResponseConstant TicketNotValid = new(false, "The ticket number entered is not valid!");

        public static readonly ResponseConstant AlreadyHasTicket = new(false, "You have already purchased the ticket you are trying to buy. You cannot buy again!");

        public static readonly ResponseConstant EventNotActive = new(false, "You cannot buy tickets as the event is not active!");

        public static readonly ResponseConstant CannotBePurchasedOwnEventTicket = new(false, "Own event tickets cannot be purchased!");
    }
}
