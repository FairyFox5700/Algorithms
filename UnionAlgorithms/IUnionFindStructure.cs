namespace Algorithms
{
    public interface IUnionFindStructure
    {
        void Union(int p, int q);
        bool Connected(int p, int q); 
        int [] data { get; set; }
    }
}