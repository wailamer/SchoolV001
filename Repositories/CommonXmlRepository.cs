using SchoolManagement.Web.Services;

namespace SchoolManagement.Web.Repositories;

public abstract class CommonXmlRepository<T>(XmlStorageHelper storage)
{
    protected abstract string FileName { get; }
    protected abstract string RootName { get; }

    public virtual IEnumerable<T> GetAll() => storage.LoadList<T>(FileName, RootName);

    public virtual void SaveAll(List<T> items) => storage.SaveList(FileName, RootName, items);
}
