using SchoolManagement.Web.Models.Domain;

namespace SchoolManagement.Web.Services;

public interface ISequenceService
{
    int Next(string key);
}

public class SequenceService(XmlStorageHelper storageHelper) : ISequenceService
{
    private const string FileName = "sequences.xml";
    private const string RootName = "Sequences";

    public int Next(string key)
    {
        var items = storageHelper.LoadList<SequenceState>(FileName, RootName);
        var state = items.FirstOrDefault(x => x.Key == key);
        if (state is null)
        {
            state = new SequenceState { Key = key, LastNumber = 0 };
            items.Add(state);
        }

        state.LastNumber++;
        storageHelper.SaveList(FileName, RootName, items);
        return state.LastNumber;
    }
}
