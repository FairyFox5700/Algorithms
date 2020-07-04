namespace QueueAndStacks.Stack
{
    public interface ILinkedListStructure<Item>
    {
        public Item pop();
        public bool isEmpty();
        public void push(Item item);
    }
}