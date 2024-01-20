namespace LifeVenture.Common
{
    public static class ErrorConstants
    {
        public class Common
        {
            public const string RequiredField = "Полето е задължително";

            public const string SelectOptionErr = "Моля, изберете опция различна от 'ИЗБЕРИ'!";

            public const string NotValidEmailAddress = "Невалиден имейл адрес!";
        }

        public class EventErrors
        {
            public const string MaxParticipantsCountErr = "Участниците могат да бъдат между 1 и 2 милиярда души!";

            public const string DescriptionMaxLength = "Описанието трябва да бъде до 3000 символа!";

            public const string MaxTitleLenght = "Заглавието трябва да бъде до 300 символа!";
        }

        public class PhoneNumberErrors
        {
            public const string NumberErr = "Телефонния номер трябва да бъде с дължина между 7 и 30 символа!";
        }
    }
}
