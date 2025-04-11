namespace Core.EventService.Events
{
    public class OnUIInit<T>
    {
        public int InstanceId { get; } 
        public T Data { get; }
        
        public OnUIInit(int instanceId,T data)
        {
            InstanceId = instanceId;
            Data = data;
        }
    }
    
    public class OnUIInit<T,T2>
    {
        public int InstanceId { get; } 
        public T Data { get; }
        public T2 ExtraData { get; }
        
        public OnUIInit(int instanceId,T data,T2 extraData)
        {
            InstanceId = instanceId;
            Data = data;
            ExtraData = extraData;
        }
    }
    
    public class OnUIInit<T,T2,T3>
    {
        public int InstanceId { get; } 
        public T Data { get; }
        public T2 ExtraData { get; }
        public T3 ExtraPlusData { get; }

        
        public OnUIInit(int instanceId,T data,T2 extraData,T3 extraPlusData)
        {
            InstanceId = instanceId;
            Data = data;
            ExtraData = extraData;
            ExtraPlusData = extraPlusData;
        }
    }
}