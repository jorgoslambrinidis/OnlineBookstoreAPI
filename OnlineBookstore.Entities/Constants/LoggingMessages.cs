namespace OnlineBookstore.Entities
{
    public static class ErrorMessages
    {
        #region Basic Error Messages 
        public const string ErrorRetievingDataFromDB = "Error retrieving data from the database!";
        public const string ErrorUpdatingData = "Error updating data!";
        public const string ErrorDeletingData = "Error deleting data!";
        public const string ErrorRetievingDataFromExternalApi = "Error retrieving data from the external API. Something wrong happend!";
        #endregion

        #region Error User Messages
        public const string ErrorCreatingUser = "Error creating new user record!";
        public const string ErrorUpdatingUser = "Error updating user record!";
        public const string ErrorDeletingUser = "Error deleting user record!";
        #endregion

        #region Error Authentication Messages
        public const string UsernameAlreadyExists = "Username already exists";
        public const string UserNotRegistered = "User not registered";
        public const string ErrorRegisteringUser = "Error registering new user!";
        #endregion

        #region Error Upload Messages
        public const string ErrorUploadingPhoto = "Error occured while uploading the photo";
        public const string ErrorUploadingPhotos = "Error occured while uploading the photos";
        public const string ErrorUploadingPDF = "Error occured while uploading the PDF file";
        #endregion

        #region Error Photo Messages
        public const string ErrorAddingNewPhoto = "Error adding new photo to server and db";
        public const string ErrorAddingNewPhotos = "Error adding a list of photos to server and db";
        public const string ErrorUpdatingPhoto = "Error updating photo in the db";
        public const string ErrorDeletingPhoto = "Error deleting photo record!";
        #endregion
    }

    public static class InfoMessages
    {
        #region Info Book Messages
        public const string BookNotFound = "The book was not found in our system.";
        public const string AllBooksTakenFromDb = "All books are taken from db.";
        #endregion

        #region Info User Messages
        public const string AllUsersAreTakenFromDB = "All users are taken from the db";
        #endregion

        #region Info Photo Messages
        public const string AllPhotosAreTakenFromDB = "All photos are taken from the db";
        public const string AllPhotosByReportIdAreTakenFromDB = "All photos by report id are taken from the db";
        public const string MultiplePhotosAddedInTheDB = "Multiple photos as range added in the db";
        #endregion

        #region Info Other
        public const string FileNotSelected = "File not selected!";
        #endregion
    }

    public class LoggerMessageDisplay
    {
        #region Logger Book Messages
        public const string BooksListed = "All books listed successfully!";
        public const string NoBooksInDB = "There is no books in the DB!";
        public const string BookFoundDisplayDetails = "Book was found in the DB, show the details of the book";
        public const string NoBookFound = "This is no book found in the DB!";
        public const string BookCreated = "New book is created in the DB";
        public const string BookNotCreatedModelStateInvalid = "New book is NOT created in the DB, ModelState is not valid";
        public const string BookEdited = "Book is edited successfully";
        public const string BookEditNotFound = "Book for editting is not found in the DB";
        public const string BookEditErrorModelStateInvalid = "Book is not edited, ModelState is not valid";
        public const string BookDeleted = "Book is deleted successfully";
        public const string BookDeletedError = "Book is NOT deleted, error happend in process of deletion";
        #endregion

        #region Logger Publisher Messages
        public const string PublishersListed = "All publishers listed successfully!";
        public const string NoPublishersInDB = "There is no publishers in the DB!";
        public const string PublisherFoundDisplayDetails = "Publisher was found in the DB, show the details of the publisher";
        public const string NoPublisherFound = "This is no publisher found in the DB!";
        public const string PublisherCreated = "New publisher is created in the DB";
        public const string PublisherNotCreatedModelStateInvalid = "New publisher is NOT created in the DB, ModelState is not valid";
        public const string PublisherEdited = "Publisher is edited successfully";
        public const string PublisherEditNotFound = "Publisher for editting is not found in the DB";
        public const string PublisherEditErrorModelStateInvalid = "Publisher is not edited, ModelState is not valid";
        public const string PublisherDeleted = "Publisher is deleted successfully";
        public const string PublisherDeletedError = "Publisher is NOT deleted, error happend in process of deletion";
        #endregion

        #region Logger Author Messages
        public const string AuthorsListed = "All authors listed successfully!";
        public const string NoAuthorsInDB = "There is no authors in the DB!";
        public const string AuthorFoundDisplayDetails = "Author was found in the DB, show the details of the author";
        public const string NoAuthorFound = "This is no author found in the DB!";
        public const string AuthorCreated = "New author is created in the DB";
        public const string AuthorNotCreatedModelStateInvalid = "New author is NOT created in the DB, ModelState is not valid";
        public const string AuthorEdited = "Author is edited successfully";
        public const string AuthorEditErrorModelStateInvalid = "Author is not edited, ModelState is not valid";
        public const string AuthorDeleted = "Author is deleted successfully";
        public const string AuthorDeletedError = "Author is NOT deleted, error happend in process of deletion";
        #endregion

        #region Logger Category Messages
        public const string CategoriesListed = "All categories listed successfully!";
        public const string NoCategoriesInDB = "There is no categories in the DB!";
        public const string CategoryFoundDisplayDetails = "Category was found in the DB, show the details of the category";
        public const string NoCategoryFound = "This is no category found in the DB!";
        public const string CategoryCreated = "New category is created in the DB";
        public const string CategoryNotCreatedModelStateInvalid = "New category is NOT created in the DB, ModelState is not valid";
        public const string CategoryEdited = "Category is edited successfully";
        public const string CategoryEditErrorModelStateInvalid = "Category is not edited, ModelState is not valid";
        public const string CategoryDeleted = "Category is deleted successfully";
        public const string CategoryDeletedError = "Category is NOT deleted, error happend in process of deletion";
        #endregion

        #region Logger Upload Photo Messages
        public const string PhotoUploaded = "Photo is successfully uploaded";
        public const string PhotoUploadedError = "Photo is NOT uploaded";
        public const string PhotosListed = "All photos listed successfully!";
        public const string NoPhotosInDB = "There is no photos in the DB!";
        public const string PhotoFoundDisplayDetails = "Photo was found in the DB, show the details of the photo";
        public const string NoPhotoFound = "This is no photo found in the DB!";
        public const string PhotoCreated = "New photo is created in the DB";
        public const string PhotoNotCreatedModelStateInvalid = "New photo is NOT created in the DB, ModelState is not valid";
        public const string PhotoEdited = "Photo is edited successfully";
        public const string PhotoEditErrorModelStateInvalid = "Photo is not edited, ModelState is not valid";
        public const string PhotoDeleted = "Photo is deleted successfully";
        public const string PhotoDeletedError = "Photo is NOT deleted, error happend in process of deletion";
        #endregion

        #region Logger User Messages
        public const string UsersListed = "All users listed successfully!";
        public const string NoUsersInDB = "There is no user in the DB!";
        public const string UserFoundDisplayDetails = "User was found in the DB, show the details of the user";
        public const string NoUserFound = "This is no user found in the DB!";
        public const string UserCreated = "New user is created in the DB";
        public const string UserNotCreatedModelStateInvalid = "New user is NOT created in the DB, ModelState is not valid";
        public const string UserEdited = "User is edited successfully";
        public const string UserEditErrorModelStateInvalid = "User is not edited, ModelState is not valid";
        public const string UserDeleted = "User is deleted successfully";
        public const string UserDeletedError = "User is NOT deleted, error happend in process of deletion";
        #endregion
    }
}
