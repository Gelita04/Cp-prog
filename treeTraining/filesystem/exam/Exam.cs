using filesystem;

public class Exam
{
    public static IFileSystem CreateFileSystem()
    {
        return new FileSystem();
    }
}

public class File : IFile, ICloneable
{
    public File(string name, int size)
    { Size = size; Name = name; }

    public File(IFile file)
    {
        Size = file.Size;
        Name = file.Name;
    }
    public int Size { get; set; }
    public string Name { get; set; }

    public Object Clone()
    {
        return new File(this);
    }
}



public class Folder : IFolder, ICloneable
{
    public string Name { get; set; }

    public IEnumerable<IFile> Files;
    public IEnumerable<IFolder> Folders;

    public Folder(string name)
    {
        Name = name;
        Files = new List<IFile>();
        Folders = new List<IFolder>();
    }
    public Folder(Folder folder)
    {
        Name = folder.Name;
        Files = new List<IFile>(folder.Files);
        Folders = new List<IFolder>(folder.Folders);
    }

    public Object Clone()
    {
        return new Folder(this);
    }

    public IFile CreateFile(string name, int size)
    {
        foreach (var file in Files)
        {
            if (file.Name == name)
                throw new Exception();
        }
        ((List<IFile>)Files).Add(new File(name, size));
        return Files.Last();
    }
    public IFolder CreateFolder(string name)
    {
        foreach (var folder in Folders)
        {
            if (folder.Name == name)
                throw new Exception();
        }
        ((List<IFolder>)Folders).Add(new Folder(name));
        return Folders.Last();
    }

    public IEnumerable<IFile> GetFiles() => (IEnumerable<IFile>)Files.OrderBy(x => x.Name);

    public IEnumerable<IFolder> GetFolders() => (IEnumerable<IFolder>)Folders.OrderBy(x => x.Name);

    public int TotalSize()
    {
        int result = 0;
        foreach (var file in Files)
        {
            result += file.Size;
        }
        foreach (var folder in Folders)
        {
            result += folder.TotalSize();
        }
        return result;
    }
}

public class FileSystem : IFileSystem
{
    IFolder Root { get; set; }

    public FileSystem()
    { Root = new Folder("/"); }
    public FileSystem(string name)
    { Root = new Folder(name); }


    public IFolder GetFolder(string path)
    {
        return GetFolder(MauricioParser(path), Root, 0);
    }
    private IFolder GetFolder(string[] path, IFolder actualFolder, int depth)
    {
        if ((((Folder)actualFolder).Folders).Count() == 0)
        { return Root; }

        foreach (var folder in ((Folder)actualFolder).Folders)
        {
            if (folder.Name == path.Last())
                return folder;

            if (folder.Name == path[depth])
                return GetFolder(path, folder, depth + 1);
        }
        throw new Exception(message: "Folder not Found");
    }


    public IFile GetFile(string path)
    {
        return GetFile(MauricioParser(path), (Folder)Root, 0);
    }
    private IFile GetFile(string[] path, Folder actualFolder, int depth)
    {
        foreach (var folder in actualFolder.Folders)
        {
            if (folder.Name == path[depth])
                return GetFile(path, (Folder)folder, depth + 1);
        }
        foreach (var file in actualFolder.Files)
        {
            if (file.Name == path.Last())
                return file;
        }
        throw new Exception(message: "File Not Found");
    }


    public IFileSystem GetRoot(string path)
    {
        return GetRoot(MauricioParser(path), Root, 0);
    }

    private IFileSystem GetRoot(string[] path, IFolder actualFolder, int depth)
    {
        foreach (var folder in ((Folder)actualFolder).Folders)
        {
            if (folder.Name == path.Last())
                return new FileSystem(folder.Name);

            if (folder.Name == path[depth])
                return GetRoot(path, folder, depth + 1);
        }
        throw new Exception(message: "RootFolder not Found");
    }


    public IEnumerable<IFile> Find(FileFilter filter)
    {
        List<IFile> result = new List<IFile>();
        Find(filter, Root, 0, result);
        return result;
    }
    private void Find(FileFilter filter, IFolder actualFolder, int depth, List<IFile> result)
    {
        foreach (IFile file in ((Folder)actualFolder).Files)
        {
            if (filter(file))
                result.Add(file);
        }

        foreach (IFolder folder in ((Folder)actualFolder).Folders)
        {
            Find(filter, folder, depth + 1, result);
        }
    }


    public void Copy(string origin, string destination)
    {
        string[] origen = MauricioParser(origin);
        string[] destino = MauricioParser(destination);
        Copy(origen, destino, Root, 0);
    }

    private void Copy(string[] origin, string[] destination, IFolder actualFolder, int depth)
    {
        Object subject = GetFileOrFolder(origin, actualFolder, 0);

        IFolder folderDestination = GetFolder(destination, actualFolder, 0);


        if (subject is IFile)
        {
            for (int i = 0; i < (((Folder)folderDestination).Files).Count(); i++)
            {
                if (((List<IFile>)((Folder)folderDestination).Files)[i].Name == ((IFile)subject).Name)
                { ((List<IFile>)((Folder)folderDestination).Files)[i] = (IFile)subject; return; }
            }
             ((List<IFile>)((Folder)folderDestination).Files).Add((IFile)subject);
        }
        else if (subject is IFolder)
        {
            for (int i = 0; i < (((Folder)folderDestination).Folders).Count(); i++)
            {

                if (((List<IFolder>)((Folder)folderDestination).Folders)[i].Name == ((IFolder)subject).Name)
                { MergeFromTo(((List<IFolder>)((Folder)folderDestination).Folders)[i], (IFolder)subject); return; }
            }
            ((List<IFolder>)((Folder)folderDestination).Folders).Add((IFolder)subject);
        }
        else
            throw new Exception(message: "q pinga hiciste");
    }
    private void MergeFromTo(IFolder fromFolder, IFolder toFolder)
    {
        for (int i = 0; i < (((Folder)fromFolder).Files).Count(); i++)
        {
            for (int j = 0; j < (((Folder)toFolder).Files).Count(); j++)
            {
                if (((List<IFile>)((Folder)fromFolder).Files)[i].Name == ((List<IFile>)((Folder)toFolder).Files)[i].Name)
                    ((List<IFile>)((Folder)toFolder).Files)[i] = ((List<IFile>)((Folder)fromFolder).Files)[i];
                else
                    ((List<IFile>)((Folder)fromFolder).Files).Add(((List<IFile>)((Folder)fromFolder).Files)[i]);

            }
        }
        foreach (IFolder fromSubFolder in ((Folder)fromFolder).Folders)
        {
            foreach (IFolder toSubFolder in ((Folder)toFolder).Folders)
            {
                if (fromSubFolder.Name == toSubFolder.Name)
                    MergeFromTo(fromSubFolder, toSubFolder);
                else
                    ((List<IFolder>)((Folder)toFolder).Folders).Add(fromSubFolder);
            }
        }

    }


    private Object GetFileOrFolder(string[] path, IFolder actualFolder, int depth)
    {
        Object result = new Object();
        try
        {
            result = ((File)GetFile(path, (Folder)actualFolder, 0)).Clone();
            return result;
        }
        catch (System.Exception)
        {
            try
            {
                result = ((Folder)GetFolder(path, (Folder)actualFolder, 0)).Clone();
                return result;
            }
            catch (System.Exception)
            {
                throw new Exception(message: "File or Folder Not Found");
            }
        }
    }


    public void Move(string origin, string destination)
    {
        string[] origen = MauricioParser(origin);
        string[] destino = MauricioParser(destination);
        Copy(origen, destino, Root, 0);
        Delete(origen, Root, 0);
    }


    public void Delete(string path)
    {

        Delete(MauricioParser(path), Root, 0);
    }
    private void Delete(string[] path, IFolder actualFolder, int depth)
    {
        foreach (IFile file in ((Folder)actualFolder).Files)
        {
            if (file.Name == path.Last())
                ((List<IFile>)((Folder)actualFolder).Files).Remove(file);
        }

        foreach (IFolder folder in ((Folder)actualFolder).Folders)
        {
            if (folder.Name == path.Last())
                ((List<IFolder>)((Folder)actualFolder).Folders).Remove(folder);
            else if (folder.Name == path[depth])
                Delete(path, actualFolder, depth + 1);
        }
    }
    private string[] MauricioParser(string path)
    {
        if (path == "/")
            return new string[] { "/" };
        return path.Split("/", StringSplitOptions.RemoveEmptyEntries);
    }

}