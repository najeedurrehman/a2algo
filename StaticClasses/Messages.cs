namespace a2Algo.StaticClasses
{
    public static class  Messages
    {
        public static string OnCreateMessage(string _type) => $"New {_type} has been created successfully.";

        public static string OnDeleteMessage(string _type) => $"The selected {_type} has been successfully deleted.";
        public static string NotFoundErrorMessage(string _type) => $"Sorry, the requested {_type} was not found.";

        public static string OnUpdateMessage = "Changes have been saved successfully.";
        public static string InternalServerErrorMessage = "Internal server error occurred while processing the request. Please try again later or contact support.";

    }
}
