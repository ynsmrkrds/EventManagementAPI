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
    }
}
