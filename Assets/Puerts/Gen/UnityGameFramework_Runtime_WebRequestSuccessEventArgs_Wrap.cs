
using System;


namespace PuertsStaticWrap
{
    public static class UnityGameFramework_Runtime_WebRequestSuccessEventArgs_Wrap
    {
        
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8ConstructorCallback))]
        private static IntPtr Constructor(IntPtr isolate, IntPtr info, int paramLen, long data)
        {
            try
            {
                
                
                {
                    
                    
                    
                    
                    {
                        
                        var result = new UnityGameFramework.Runtime.WebRequestSuccessEventArgs();
                        
                        
                        return Puerts.Utils.GetObjectPtr((int)data, typeof(UnityGameFramework.Runtime.WebRequestSuccessEventArgs), result);
                    }
                    
                }
                
                
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
            return IntPtr.Zero;
        }
        
        
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        private static void M_GetWebResponseBytes(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as UnityGameFramework.Runtime.WebRequestSuccessEventArgs;
                
                
                {
                    
                    
                    
                    
                    {
                        
                        var result = obj.GetWebResponseBytes();
                        
                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        
                        
                    }
                    
                }
                
                
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        
        
        
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        private static void F_Create(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                
                
                
                {
                    
                    var argHelper0 = new Puerts.ArgumentHelper((int)data, isolate, info, 0);
                    
                    
                    
                    {
                        
                        var Arg0 = argHelper0.Get<GameFramework.WebRequest.WebRequestSuccessEventArgs>(false);
                        var result = UnityGameFramework.Runtime.WebRequestSuccessEventArgs.Create(Arg0);
                        
                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        
                        
                    }
                    
                }
                
                
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        
        
        
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        private static void M_Clear(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as UnityGameFramework.Runtime.WebRequestSuccessEventArgs;
                
                
                {
                    
                    
                    
                    
                    {
                        
                        obj.Clear();
                        
                        
                        
                        
                    }
                    
                }
                
                
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        
        

        
        
        
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        private static void G_Id(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as UnityGameFramework.Runtime.WebRequestSuccessEventArgs;
                var result = obj.Id;
                Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        
        
        
        
        
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        private static void G_SerialId(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as UnityGameFramework.Runtime.WebRequestSuccessEventArgs;
                var result = obj.SerialId;
                Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        
        
        
        
        
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        private static void G_WebRequestUri(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as UnityGameFramework.Runtime.WebRequestSuccessEventArgs;
                var result = obj.WebRequestUri;
                Puerts.PuertsDLL.ReturnString(isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        
        
        
        
        
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        private static void G_UserData(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as UnityGameFramework.Runtime.WebRequestSuccessEventArgs;
                var result = obj.UserData;
                Puerts.ResultHelper.Set((int)data, isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        
        
        
        
        
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        private static void G_EventId(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                
                var result = UnityGameFramework.Runtime.WebRequestSuccessEventArgs.EventId;
                Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(isolate, "c# exception:" + e.Message + ",stack:" + e.StackTrace);
            }
        }
        
        
        

        
        
        
        
        public static Puerts.TypeRegisterInfo GetRegisterInfo()
        {
            return new Puerts.TypeRegisterInfo()
            {
                BlittableCopy = false,
                Constructor = Constructor,
                Methods = new System.Collections.Generic.Dictionary<Puerts.MethodKey, Puerts.V8FunctionCallback>()
                {
                    
                    { new Puerts.MethodKey {Name = "GetWebResponseBytes", IsStatic = false}, M_GetWebResponseBytes },
                    
                    { new Puerts.MethodKey {Name = "Create", IsStatic = true}, F_Create },
                    
                    { new Puerts.MethodKey {Name = "Clear", IsStatic = false}, M_Clear },
                    
                    
                    
                    
                    
                },
                Properties = new System.Collections.Generic.Dictionary<string, Puerts.PropertyRegisterInfo>()
                {
                    
                    {"Id", new Puerts.PropertyRegisterInfo(){ IsStatic = false, Getter = G_Id, Setter = null} },
                    
                    {"SerialId", new Puerts.PropertyRegisterInfo(){ IsStatic = false, Getter = G_SerialId, Setter = null} },
                    
                    {"WebRequestUri", new Puerts.PropertyRegisterInfo(){ IsStatic = false, Getter = G_WebRequestUri, Setter = null} },
                    
                    {"UserData", new Puerts.PropertyRegisterInfo(){ IsStatic = false, Getter = G_UserData, Setter = null} },
                    
                    {"EventId", new Puerts.PropertyRegisterInfo(){ IsStatic = true, Getter = G_EventId, Setter = null} },
                    
                },
                LazyMethods = new System.Collections.Generic.Dictionary<Puerts.MethodKey, Puerts.V8FunctionCallback>()
                {
                    
                    
                    
                    
                    
                },
                LazyProperties = new System.Collections.Generic.Dictionary<string, Puerts.PropertyRegisterInfo>()
                {
                    
                }
            };
        }
        
    }
}