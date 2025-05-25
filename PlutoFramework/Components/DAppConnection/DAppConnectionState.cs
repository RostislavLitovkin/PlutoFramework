namespace PlutoFramework.Components.DAppConnection
{
    public enum DAppConnectionStateEnum
    {
        Waiting,
        Connecting,
        Confirming,
        Connected,

        Rejected,
        Disconnected,

        Reconnecting,
    }
}