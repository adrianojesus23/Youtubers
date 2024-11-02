namespace IsNullEmptyList.Helps;

public static class ExtensionsMethods
{
   public static string CheckIsNull<T>(this IEnumerable<T> list)
   {
      return !(list?.Any() ?? false)? "Is null": "Not null";
   }
   
   public static bool CheckIsCount<T>(this IEnumerable<T> list)
   {
      return (list is not null && !list.Any());
   }
   
   public static bool IsNullEmpty<T>(this IEnumerable<T> list)
   {
      return (list is null || !list.Any());
   }
}