namespace Infrostructure.Exeption
{
   public class NotFoundDescriptionExeption:System.Exception
    {
        public NotFoundDescriptionExeption(string message = "Can not find description") :base(message){}
    }
}
