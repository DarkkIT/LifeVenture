namespace LifeVenture.Common
{
    public static class ErrorConstants
    {
        public class Common
        {
            public const string RequiredField = "Полето е задължително";

            public const string SelectOptionErr = "Моля, изберете опция различна от 'ИЗБЕРИ'!";

            public const string NotValidEmailAddress = "Невалиден имейл адрес!";

            public const string ImageIsRequired = "Снимката е задължителна!";
        }

        public class EventErrors
        {
            public const string MaxParticipantsCountErr = "Участниците могат да бъдат между 1 и 2 милиярда души!";

            public const string DescriptionMaxLength = "Описанието трябва да бъде до 3000 символа!";

            public const string MaxTitleLenght = "Заглавието трябва да бъде до 300 символа!";

            public const string EndDateErr = "Крайната дата не може да бъде по-малка или равна на началната дата на събитието!";
        }

        public class PhoneNumberErrors
        {
            public const string NumberErr = "Телефонния номер трябва да бъде с дължина между 7 и 30 символа!";
        }

        public class ImageErrors
        {
            public const string Image = "Image";

            public const string ImageMaxSizeErr = "Снимката не може да бъде по-голяма от 10 MB.";
        }
    }
}
