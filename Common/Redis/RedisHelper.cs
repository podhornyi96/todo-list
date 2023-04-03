using System.Text;
using Newtonsoft.Json;

namespace TodoListService.Common.Redis;

public static class RedisHelper
{
    public static TEntity Deserialize<TEntity>(byte[] data)
    {
        var json = Encoding.UTF8.GetString(data);
        var result = JsonConvert.DeserializeObject<TEntity>(json);
        
        return result; 
    }

    public static byte[] Serialize<TEntity>(TEntity entity)
    {
        var json = JsonConvert.SerializeObject(entity);
        var result = Encoding.UTF8.GetBytes(json);

        return result;
    }
    
}