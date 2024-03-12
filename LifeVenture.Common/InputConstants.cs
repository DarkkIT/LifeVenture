namespace LifeVenture.Common
{
    public static class InputConstants
    {
        public class InputCommonConstants
        {
            public const int MinNumber = 1;

            public const int RequestSizeLimit = 20 * 1024 * 1024;

            public const string EndDate = "EndDate";
        }

        public class InputEventsConstants
        {
            public const string EventTitle = "Заглавие";

            public const int MaxEventTitleLenghtNumber = 200;

            public const string EventDescription = "Описание";

            public const int MaxEventDescriptionLenghtNumber = 3000;

            public const string EventStartDate = "Начална дата";

            public const string EventEndDate = "Крайна дата";

            public const string EventUrgency = "Спешен евент";

            public const string EventMaxParticipants = "Максимален брой участници";

            public const int EventMaxParticipantsMaxNumber = 2000000000;

            public const string EventEmail = "Имейл";

            public const string EventCategory = "Категория";
        }

        public class InputPhoneConstants
        {
            public const string PhoneNumber = "Телефонен номер";

            public const string PhoneCode = "Код на държава";

            public const int MaxPhoneNumberLenght = 30;

            public const int MinPhoneNumberLenght = 7;
        }

        public class InputLocationConstants
        {
            public const string LocationRegion = "Регион";

            public const string LocationMunicipality = "Община";

            public const string LocationSettlement = "Населено място";

            public const string LocationAddressNote = "Уточнение за адрес";
        }

        public class InputImageConstants
        {
            public const int ImageMaxSizeMb = 10 * 1024 * 1024;

            public const double AspectRatioNumber = 1.778;

            public const int ThumbnailWidth = 600;

            public const int FullscreenWidth = 1000;

            public const int Quality = 75;
        }
    }
}
