static void Replace(List<string> aList, string oldItem, string newItem)
{
    foreach (var item in aList)
    {
        if (item.Equals(oldItem, StringComparison.InvariantCultureIgnoreCase))
        {
            var index = aList.IndexOf(item);
            aList[index] = newItem;
        }
    }
}