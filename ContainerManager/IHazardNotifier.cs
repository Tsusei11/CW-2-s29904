namespace ContainerManager;

public interface IHazardNotifier
{
    public bool IsHazardous { get; }

    public void Notify();
}