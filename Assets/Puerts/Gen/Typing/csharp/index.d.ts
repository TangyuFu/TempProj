
declare module 'csharp' {
    interface $Ref<T> {
        value: T
    }
    
    namespace System {
        interface Array$1<T> extends System.Array {
            get_Item(index: number):T;
            
            set_Item(index: number, value: T):void;
        }
    }
    
    interface $Task<T> {}
    
    namespace System {
        
        class Type extends System.Reflection.MemberInfo implements System.Runtime.InteropServices._MemberInfo, System.Runtime.InteropServices._Type, System.Reflection.ICustomAttributeProvider, System.Reflection.IReflect{ 
            
            public static Delimiter: number;
            
            public static EmptyTypes: System.Array$1<System.Type>;
            
            public static Missing: any;
            
            public static FilterAttribute: System.Reflection.MemberFilter;
            
            public static FilterName: System.Reflection.MemberFilter;
            
            public static FilterNameIgnoreCase: System.Reflection.MemberFilter;
            
            public get IsSerializable(): boolean;
            
            
            public get ContainsGenericParameters(): boolean;
            
            
            public get IsVisible(): boolean;
            
            
            public get MemberType(): System.Reflection.MemberTypes;
            
            
            public get Namespace(): string;
            
            
            public get AssemblyQualifiedName(): string;
            
            
            public get FullName(): string;
            
            
            public get Assembly(): System.Reflection.Assembly;
            
            
            public get Module(): System.Reflection.Module;
            
            
            public get IsNested(): boolean;
            
            
            public get DeclaringType(): System.Type;
            
            
            public get DeclaringMethod(): System.Reflection.MethodBase;
            
            
            public get ReflectedType(): System.Type;
            
            
            public get UnderlyingSystemType(): System.Type;
            
            
            public get IsTypeDefinition(): boolean;
            
            
            public get IsArray(): boolean;
            
            
            public get IsByRef(): boolean;
            
            
            public get IsPointer(): boolean;
            
            
            public get IsConstructedGenericType(): boolean;
            
            
            public get IsGenericParameter(): boolean;
            
            
            public get IsGenericTypeParameter(): boolean;
            
            
            public get IsGenericMethodParameter(): boolean;
            
            
            public get IsGenericType(): boolean;
            
            
            public get IsGenericTypeDefinition(): boolean;
            
            
            public get IsSZArray(): boolean;
            
            
            public get IsVariableBoundArray(): boolean;
            
            
            public get IsByRefLike(): boolean;
            
            
            public get HasElementType(): boolean;
            
            
            public get GenericTypeArguments(): System.Array$1<System.Type>;
            
            
            public get GenericParameterPosition(): number;
            
            
            public get GenericParameterAttributes(): System.Reflection.GenericParameterAttributes;
            
            
            public get Attributes(): System.Reflection.TypeAttributes;
            
            
            public get IsAbstract(): boolean;
            
            
            public get IsImport(): boolean;
            
            
            public get IsSealed(): boolean;
            
            
            public get IsSpecialName(): boolean;
            
            
            public get IsClass(): boolean;
            
            
            public get IsNestedAssembly(): boolean;
            
            
            public get IsNestedFamANDAssem(): boolean;
            
            
            public get IsNestedFamily(): boolean;
            
            
            public get IsNestedFamORAssem(): boolean;
            
            
            public get IsNestedPrivate(): boolean;
            
            
            public get IsNestedPublic(): boolean;
            
            
            public get IsNotPublic(): boolean;
            
            
            public get IsPublic(): boolean;
            
            
            public get IsAutoLayout(): boolean;
            
            
            public get IsExplicitLayout(): boolean;
            
            
            public get IsLayoutSequential(): boolean;
            
            
            public get IsAnsiClass(): boolean;
            
            
            public get IsAutoClass(): boolean;
            
            
            public get IsUnicodeClass(): boolean;
            
            
            public get IsCOMObject(): boolean;
            
            
            public get IsContextful(): boolean;
            
            
            public get IsCollectible(): boolean;
            
            
            public get IsEnum(): boolean;
            
            
            public get IsMarshalByRef(): boolean;
            
            
            public get IsPrimitive(): boolean;
            
            
            public get IsValueType(): boolean;
            
            
            public get IsSignatureType(): boolean;
            
            
            public get IsSecurityCritical(): boolean;
            
            
            public get IsSecuritySafeCritical(): boolean;
            
            
            public get IsSecurityTransparent(): boolean;
            
            
            public get StructLayoutAttribute(): System.Runtime.InteropServices.StructLayoutAttribute;
            
            
            public get TypeInitializer(): System.Reflection.ConstructorInfo;
            
            
            public get TypeHandle(): System.RuntimeTypeHandle;
            
            
            public get GUID(): System.Guid;
            
            
            public get BaseType(): System.Type;
            
            
            public static get DefaultBinder(): System.Reflection.Binder;
            
            
            public get IsInterface(): boolean;
            
            
            public IsEnumDefined($value: any):boolean;
            
            public GetEnumName($value: any):string;
            
            public GetEnumNames():System.Array$1<string>;
            
            public FindInterfaces($filter: System.Reflection.TypeFilter, $filterCriteria: any):System.Array$1<System.Type>;
            
            public FindMembers($memberType: System.Reflection.MemberTypes, $bindingAttr: System.Reflection.BindingFlags, $filter: System.Reflection.MemberFilter, $filterCriteria: any):System.Array$1<System.Reflection.MemberInfo>;
            
            public IsSubclassOf($c: System.Type):boolean;
            
            public IsAssignableFrom($c: System.Type):boolean;
            
            public GetType():System.Type;
            
            public GetElementType():System.Type;
            
            public GetArrayRank():number;
            
            public GetGenericTypeDefinition():System.Type;
            
            public GetGenericArguments():System.Array$1<System.Type>;
            
            public GetGenericParameterConstraints():System.Array$1<System.Type>;
            
            public GetConstructor($types: System.Array$1<System.Type>):System.Reflection.ConstructorInfo;
            
            public GetConstructor($bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>):System.Reflection.ConstructorInfo;
            
            public GetConstructor($bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $callConvention: System.Reflection.CallingConventions, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>):System.Reflection.ConstructorInfo;
            
            public GetConstructors():System.Array$1<System.Reflection.ConstructorInfo>;
            
            public GetConstructors($bindingAttr: System.Reflection.BindingFlags):System.Array$1<System.Reflection.ConstructorInfo>;
            
            public GetEvent($name: string):System.Reflection.EventInfo;
            
            public GetEvent($name: string, $bindingAttr: System.Reflection.BindingFlags):System.Reflection.EventInfo;
            
            public GetEvents():System.Array$1<System.Reflection.EventInfo>;
            
            public GetEvents($bindingAttr: System.Reflection.BindingFlags):System.Array$1<System.Reflection.EventInfo>;
            
            public GetField($name: string):System.Reflection.FieldInfo;
            
            public GetField($name: string, $bindingAttr: System.Reflection.BindingFlags):System.Reflection.FieldInfo;
            
            public GetFields():System.Array$1<System.Reflection.FieldInfo>;
            
            public GetFields($bindingAttr: System.Reflection.BindingFlags):System.Array$1<System.Reflection.FieldInfo>;
            
            public GetMember($name: string):System.Array$1<System.Reflection.MemberInfo>;
            
            public GetMember($name: string, $bindingAttr: System.Reflection.BindingFlags):System.Array$1<System.Reflection.MemberInfo>;
            
            public GetMember($name: string, $type: System.Reflection.MemberTypes, $bindingAttr: System.Reflection.BindingFlags):System.Array$1<System.Reflection.MemberInfo>;
            
            public GetMembers():System.Array$1<System.Reflection.MemberInfo>;
            
            public GetMembers($bindingAttr: System.Reflection.BindingFlags):System.Array$1<System.Reflection.MemberInfo>;
            
            public GetMethod($name: string):System.Reflection.MethodInfo;
            
            public GetMethod($name: string, $bindingAttr: System.Reflection.BindingFlags):System.Reflection.MethodInfo;
            
            public GetMethod($name: string, $types: System.Array$1<System.Type>):System.Reflection.MethodInfo;
            
            public GetMethod($name: string, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>):System.Reflection.MethodInfo;
            
            public GetMethod($name: string, $bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>):System.Reflection.MethodInfo;
            
            public GetMethod($name: string, $bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $callConvention: System.Reflection.CallingConventions, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>):System.Reflection.MethodInfo;
            
            public GetMethod($name: string, $genericParameterCount: number, $types: System.Array$1<System.Type>):System.Reflection.MethodInfo;
            
            public GetMethod($name: string, $genericParameterCount: number, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>):System.Reflection.MethodInfo;
            
            public GetMethod($name: string, $genericParameterCount: number, $bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>):System.Reflection.MethodInfo;
            
            public GetMethod($name: string, $genericParameterCount: number, $bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $callConvention: System.Reflection.CallingConventions, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>):System.Reflection.MethodInfo;
            
            public GetMethods():System.Array$1<System.Reflection.MethodInfo>;
            
            public GetMethods($bindingAttr: System.Reflection.BindingFlags):System.Array$1<System.Reflection.MethodInfo>;
            
            public GetNestedType($name: string):System.Type;
            
            public GetNestedType($name: string, $bindingAttr: System.Reflection.BindingFlags):System.Type;
            
            public GetNestedTypes():System.Array$1<System.Type>;
            
            public GetNestedTypes($bindingAttr: System.Reflection.BindingFlags):System.Array$1<System.Type>;
            
            public GetProperty($name: string):System.Reflection.PropertyInfo;
            
            public GetProperty($name: string, $bindingAttr: System.Reflection.BindingFlags):System.Reflection.PropertyInfo;
            
            public GetProperty($name: string, $returnType: System.Type):System.Reflection.PropertyInfo;
            
            public GetProperty($name: string, $types: System.Array$1<System.Type>):System.Reflection.PropertyInfo;
            
            public GetProperty($name: string, $returnType: System.Type, $types: System.Array$1<System.Type>):System.Reflection.PropertyInfo;
            
            public GetProperty($name: string, $returnType: System.Type, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>):System.Reflection.PropertyInfo;
            
            public GetProperty($name: string, $bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $returnType: System.Type, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>):System.Reflection.PropertyInfo;
            
            public GetProperties():System.Array$1<System.Reflection.PropertyInfo>;
            
            public GetProperties($bindingAttr: System.Reflection.BindingFlags):System.Array$1<System.Reflection.PropertyInfo>;
            
            public GetDefaultMembers():System.Array$1<System.Reflection.MemberInfo>;
            
            public static GetTypeHandle($o: any):System.RuntimeTypeHandle;
            
            public static GetTypeArray($args: System.Array$1<any>):System.Array$1<System.Type>;
            
            public static GetTypeCode($type: System.Type):System.TypeCode;
            
            public static GetTypeFromCLSID($clsid: System.Guid):System.Type;
            
            public static GetTypeFromCLSID($clsid: System.Guid, $throwOnError: boolean):System.Type;
            
            public static GetTypeFromCLSID($clsid: System.Guid, $server: string):System.Type;
            
            public static GetTypeFromProgID($progID: string):System.Type;
            
            public static GetTypeFromProgID($progID: string, $throwOnError: boolean):System.Type;
            
            public static GetTypeFromProgID($progID: string, $server: string):System.Type;
            
            public InvokeMember($name: string, $invokeAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $target: any, $args: System.Array$1<any>):any;
            
            public InvokeMember($name: string, $invokeAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $target: any, $args: System.Array$1<any>, $culture: System.Globalization.CultureInfo):any;
            
            public InvokeMember($name: string, $invokeAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $target: any, $args: System.Array$1<any>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>, $culture: System.Globalization.CultureInfo, $namedParameters: System.Array$1<string>):any;
            
            public GetInterface($name: string):System.Type;
            
            public GetInterface($name: string, $ignoreCase: boolean):System.Type;
            
            public GetInterfaces():System.Array$1<System.Type>;
            
            public GetInterfaceMap($interfaceType: System.Type):System.Reflection.InterfaceMapping;
            
            public IsInstanceOfType($o: any):boolean;
            
            public IsEquivalentTo($other: System.Type):boolean;
            
            public GetEnumUnderlyingType():System.Type;
            
            public GetEnumValues():System.Array;
            
            public MakeArrayType():System.Type;
            
            public MakeArrayType($rank: number):System.Type;
            
            public MakeByRefType():System.Type;
            
            public MakeGenericType(...typeArguments: System.Type[]):System.Type;
            
            public MakePointerType():System.Type;
            
            public static MakeGenericSignatureType($genericTypeDefinition: System.Type, ...typeArguments: System.Type[]):System.Type;
            
            public static MakeGenericMethodParameter($position: number):System.Type;
            
            public Equals($o: any):boolean;
            
            public Equals($o: System.Type):boolean;
            
            public static GetTypeFromHandle($handle: System.RuntimeTypeHandle):System.Type;
            
            public static GetType($typeName: string, $throwOnError: boolean, $ignoreCase: boolean):System.Type;
            
            public static GetType($typeName: string, $throwOnError: boolean):System.Type;
            
            public static GetType($typeName: string):System.Type;
            
            public static GetType($typeName: string, $assemblyResolver: System.Func$2<System.Reflection.AssemblyName, System.Reflection.Assembly>, $typeResolver: System.Func$4<System.Reflection.Assembly, string, boolean, System.Type>):System.Type;
            
            public static GetType($typeName: string, $assemblyResolver: System.Func$2<System.Reflection.AssemblyName, System.Reflection.Assembly>, $typeResolver: System.Func$4<System.Reflection.Assembly, string, boolean, System.Type>, $throwOnError: boolean):System.Type;
            
            public static GetType($typeName: string, $assemblyResolver: System.Func$2<System.Reflection.AssemblyName, System.Reflection.Assembly>, $typeResolver: System.Func$4<System.Reflection.Assembly, string, boolean, System.Type>, $throwOnError: boolean, $ignoreCase: boolean):System.Type;
            
            public static op_Equality($left: System.Type, $right: System.Type):boolean;
            
            public static op_Inequality($left: System.Type, $right: System.Type):boolean;
            
            public static ReflectionOnlyGetType($typeName: string, $throwIfNotFound: boolean, $ignoreCase: boolean):System.Type;
            
            public static GetTypeFromCLSID($clsid: System.Guid, $server: string, $throwOnError: boolean):System.Type;
            
            public static GetTypeFromProgID($progID: string, $server: string, $throwOnError: boolean):System.Type;
            
        }
        
        
        class Object{ 
            
        }
        
        
        class Char extends System.ValueType implements System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>{ 
            
        }
        
        
        class ValueType extends System.Object{ 
            
        }
        
        
        interface IComparable{ 
            
        }
        
        
        interface IComparable$1<T>{ 
            
        }
        
        
        interface IConvertible{ 
            
        }
        
        
        interface IEquatable$1<T>{ 
            
        }
        
        
        class Boolean extends System.ValueType implements System.IComparable, System.IComparable$1<boolean>, System.IConvertible, System.IEquatable$1<boolean>{ 
            
        }
        
        
        interface MulticastDelegate { (...args:any[]) : any; } 
        var MulticastDelegate: {new (func: (...args:any[]) => any): MulticastDelegate;}
        
        
        class Delegate extends System.Object implements System.Runtime.Serialization.ISerializable, System.ICloneable{ 
            
        }
        
        
        interface ICloneable{ 
            
        }
        
        
        class String extends System.Object implements System.ICloneable, System.IComparable, System.IComparable$1<string>, System.IConvertible, System.Collections.Generic.IEnumerable$1<number>, System.Collections.IEnumerable, System.IEquatable$1<string>{ 
            
        }
        
        
        class Enum extends System.ValueType implements System.IFormattable, System.IComparable, System.IConvertible{ 
            
        }
        
        
        interface IFormattable{ 
            
        }
        
        
        class Int32 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>{ 
            
        }
        
        
        interface ISpanFormattable{ 
            
        }
        
        
        class Attribute extends System.Object implements System.Runtime.InteropServices._Attribute{ 
            
        }
        
        
        class Array extends System.Object implements System.Collections.IStructuralComparable, System.Collections.IStructuralEquatable, System.ICloneable, System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList{ 
            
        }
        
        
        class RuntimeTypeHandle extends System.ValueType implements System.Runtime.Serialization.ISerializable{ 
            
        }
        
        
        enum TypeCode{ Empty = 0, Object = 1, DBNull = 2, Boolean = 3, Char = 4, SByte = 5, Byte = 6, Int16 = 7, UInt16 = 8, Int32 = 9, UInt32 = 10, Int64 = 11, UInt64 = 12, Single = 13, Double = 14, Decimal = 15, DateTime = 16, String = 18 }
        
        
        class Guid extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<System.Guid>, System.IEquatable$1<System.Guid>{ 
            
        }
        
        
        interface IFormatProvider{ 
            
        }
        
        
        interface Func$2<T, TResult> { (arg: T) : TResult; } 
        
        
        interface Func$4<T1, T2, T3, TResult> { (arg1: T1, arg2: T2, arg3: T3) : TResult; } 
        
        
        class Void extends System.ValueType{ 
            
        }
        
        
        class Single extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>{ 
            
        }
        
        
        class Exception extends System.Object implements System.Runtime.Serialization.ISerializable, System.Runtime.InteropServices._Exception{ 
            
        }
        
        
        class Double extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>{ 
            
        }
        
        
        class UInt64 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<bigint>, System.IConvertible, System.IEquatable$1<bigint>{ 
            
        }
        
        
        interface IDisposable{ 
            
        }
        
        
        class UInt32 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>{ 
            
        }
        
        
        interface Func$3<T1, T2, TResult> { (arg1: T1, arg2: T2) : TResult; } 
        
        
        interface Action$1<T> { (obj: T) : void; } 
        
        
        class EventArgs extends System.Object{ 
            
        }
        
        
        class Int64 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<bigint>, System.IConvertible, System.IEquatable$1<bigint>{ 
            
        }
        
        
        interface EventHandler$1<TEventArgs> { (sender: any, e: TEventArgs) : void; } 
        
        
        class Byte extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>{ 
            
        }
        
        
        class DateTime extends System.ValueType implements System.IFormattable, System.Runtime.Serialization.ISerializable, System.ISpanFormattable, System.IComparable, System.IComparable$1<Date>, System.IConvertible, System.IEquatable$1<Date>{ 
            
        }
        
        
        interface Action { () : void; } 
        var Action: {new (func: () => void): Action;}
        
        
    }
    namespace System.Reflection {
        
        class MemberInfo extends System.Object implements System.Runtime.InteropServices._MemberInfo, System.Reflection.ICustomAttributeProvider{ 
            
        }
        
        
        interface ICustomAttributeProvider{ 
            
        }
        
        
        interface IReflect{ 
            
        }
        
        
        interface MemberFilter { (m: System.Reflection.MemberInfo, filterCriteria: any) : boolean; } 
        var MemberFilter: {new (func: (m: System.Reflection.MemberInfo, filterCriteria: any) => boolean): MemberFilter;}
        
        
        interface TypeFilter { (m: System.Type, filterCriteria: any) : boolean; } 
        var TypeFilter: {new (func: (m: System.Type, filterCriteria: any) => boolean): TypeFilter;}
        
        
        enum MemberTypes{ Constructor = 1, Event = 2, Field = 4, Method = 8, Property = 16, TypeInfo = 32, Custom = 64, NestedType = 128, All = 191 }
        
        
        enum BindingFlags{ Default = 0, IgnoreCase = 1, DeclaredOnly = 2, Instance = 4, Static = 8, Public = 16, NonPublic = 32, FlattenHierarchy = 64, InvokeMethod = 256, CreateInstance = 512, GetField = 1024, SetField = 2048, GetProperty = 4096, SetProperty = 8192, PutDispProperty = 16384, PutRefDispProperty = 32768, ExactBinding = 65536, SuppressChangeType = 131072, OptionalParamBinding = 262144, IgnoreReturn = 16777216, DoNotWrapExceptions = 33554432 }
        
        
        class Assembly extends System.Object implements System.Runtime.Serialization.ISerializable, System.Reflection.ICustomAttributeProvider, System.Security.IEvidenceFactory, System.Runtime.InteropServices._Assembly{ 
            
        }
        
        
        class Module extends System.Object implements System.Runtime.Serialization.ISerializable, System.Runtime.InteropServices._Module, System.Reflection.ICustomAttributeProvider{ 
            
        }
        
        
        class MethodBase extends System.Reflection.MemberInfo implements System.Runtime.InteropServices._MemberInfo, System.Runtime.InteropServices._MethodBase, System.Reflection.ICustomAttributeProvider{ 
            
        }
        
        
        enum GenericParameterAttributes{ None = 0, VarianceMask = 3, Covariant = 1, Contravariant = 2, SpecialConstraintMask = 28, ReferenceTypeConstraint = 4, NotNullableValueTypeConstraint = 8, DefaultConstructorConstraint = 16 }
        
        
        enum TypeAttributes{ VisibilityMask = 7, NotPublic = 0, Public = 1, NestedPublic = 2, NestedPrivate = 3, NestedFamily = 4, NestedAssembly = 5, NestedFamANDAssem = 6, NestedFamORAssem = 7, LayoutMask = 24, AutoLayout = 0, SequentialLayout = 8, ExplicitLayout = 16, ClassSemanticsMask = 32, Class = 0, Interface = 32, Abstract = 128, Sealed = 256, SpecialName = 1024, Import = 4096, Serializable = 8192, WindowsRuntime = 16384, StringFormatMask = 196608, AnsiClass = 0, UnicodeClass = 65536, AutoClass = 131072, CustomFormatClass = 196608, CustomFormatMask = 12582912, BeforeFieldInit = 1048576, RTSpecialName = 2048, HasSecurity = 262144, ReservedMask = 264192 }
        
        
        class ConstructorInfo extends System.Reflection.MethodBase implements System.Runtime.InteropServices._MemberInfo, System.Runtime.InteropServices._MethodBase, System.Runtime.InteropServices._ConstructorInfo, System.Reflection.ICustomAttributeProvider{ 
            
        }
        
        
        class Binder extends System.Object{ 
            
        }
        
        
        class ParameterModifier extends System.ValueType{ 
            
        }
        
        
        enum CallingConventions{ Standard = 1, VarArgs = 2, Any = 3, HasThis = 32, ExplicitThis = 64 }
        
        
        class EventInfo extends System.Reflection.MemberInfo implements System.Runtime.InteropServices._MemberInfo, System.Runtime.InteropServices._EventInfo, System.Reflection.ICustomAttributeProvider{ 
            
        }
        
        
        class FieldInfo extends System.Reflection.MemberInfo implements System.Runtime.InteropServices._MemberInfo, System.Reflection.ICustomAttributeProvider, System.Runtime.InteropServices._FieldInfo{ 
            
        }
        
        
        class MethodInfo extends System.Reflection.MethodBase implements System.Runtime.InteropServices._MemberInfo, System.Runtime.InteropServices._MethodBase, System.Runtime.InteropServices._MethodInfo, System.Reflection.ICustomAttributeProvider{ 
            
        }
        
        
        class PropertyInfo extends System.Reflection.MemberInfo implements System.Runtime.InteropServices._PropertyInfo, System.Runtime.InteropServices._MemberInfo, System.Reflection.ICustomAttributeProvider{ 
            
        }
        
        
        class InterfaceMapping extends System.ValueType{ 
            
        }
        
        
        class AssemblyName extends System.Object implements System.Runtime.InteropServices._AssemblyName, System.Runtime.Serialization.IDeserializationCallback, System.Runtime.Serialization.ISerializable, System.ICloneable{ 
            
        }
        
        
    }
    namespace System.Runtime.InteropServices {
        
        interface _MemberInfo{ 
            
        }
        
        
        interface _Type{ 
            
        }
        
        
        interface _Assembly{ 
            
        }
        
        
        interface _Module{ 
            
        }
        
        
        interface _MethodBase{ 
            
        }
        
        
        class StructLayoutAttribute extends System.Attribute implements System.Runtime.InteropServices._Attribute{ 
            
        }
        
        
        interface _Attribute{ 
            
        }
        
        
        interface _ConstructorInfo{ 
            
        }
        
        
        interface _EventInfo{ 
            
        }
        
        
        interface _FieldInfo{ 
            
        }
        
        
        interface _MethodInfo{ 
            
        }
        
        
        interface _PropertyInfo{ 
            
        }
        
        
        interface _AssemblyName{ 
            
        }
        
        
        interface _Exception{ 
            
        }
        
        
    }
    namespace System.Runtime.Serialization {
        
        interface ISerializable{ 
            
        }
        
        
        interface IDeserializationCallback{ 
            
        }
        
        
    }
    namespace System.Collections.Generic {
        
        interface IEnumerable$1<T> extends System.Collections.IEnumerable{ 
            
        }
        
        
        interface IReadOnlyList$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.IReadOnlyCollection$1<T>{ 
            
        }
        
        
        interface IReadOnlyCollection$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable{ 
            
        }
        
        
        interface IList$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.ICollection$1<T>{ 
            
        }
        
        
        interface ICollection$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable{ 
            
        }
        
        
        class List$1<T> extends System.Object implements System.Collections.Generic.IReadOnlyList$1<T>, System.Collections.ICollection, System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.IList$1<T>, System.Collections.Generic.IReadOnlyCollection$1<T>, System.Collections.IList, System.Collections.Generic.ICollection$1<T>{ 
            
        }
        
        
    }
    namespace System.Collections {
        
        interface IEnumerable{ 
            
        }
        
        
        interface IStructuralComparable{ 
            
        }
        
        
        interface IStructuralEquatable{ 
            
        }
        
        
        interface ICollection extends System.Collections.IEnumerable{ 
            
        }
        
        
        interface IList extends System.Collections.ICollection, System.Collections.IEnumerable{ 
            
        }
        
        
        interface IEnumerator{ 
            
        }
        
        
    }
    namespace System.Security {
        
        interface IEvidenceFactory{ 
            
        }
        
        
    }
    namespace System.Globalization {
        
        class CultureInfo extends System.Object implements System.ICloneable, System.IFormatProvider{ 
            
        }
        
        
    }
    namespace UnityEngine {
        /** Class containing methods to ease debugging while developing a game. */
        class Debug extends System.Object{ 
            /** Get default debug logger. */
            public static get unityLogger(): UnityEngine.ILogger;
            
            /** Reports whether the development console is visible. The development console cannot be made to appear using: */
            public static get developerConsoleVisible(): boolean;
            public static set developerConsoleVisible(value: boolean);
            /** In the Build Settings dialog there is a check box called "Development Build". */
            public static get isDebugBuild(): boolean;
            
            /** Draws a line between specified start and end points. * @param start Point in world space where the line should start.
             * @param end Point in world space where the line should end.
             * @param color Color of the line.
             * @param duration How long the line should be visible for.
             * @param depthTest Should the line be obscured by objects closer to the camera?
             */
            public static DrawLine($start: UnityEngine.Vector3, $end: UnityEngine.Vector3, $color: UnityEngine.Color, $duration: number):void;
            /** Draws a line between specified start and end points. * @param start Point in world space where the line should start.
             * @param end Point in world space where the line should end.
             * @param color Color of the line.
             * @param duration How long the line should be visible for.
             * @param depthTest Should the line be obscured by objects closer to the camera?
             */
            public static DrawLine($start: UnityEngine.Vector3, $end: UnityEngine.Vector3, $color: UnityEngine.Color):void;
            /** Draws a line between specified start and end points. * @param start Point in world space where the line should start.
             * @param end Point in world space where the line should end.
             * @param color Color of the line.
             * @param duration How long the line should be visible for.
             * @param depthTest Should the line be obscured by objects closer to the camera?
             */
            public static DrawLine($start: UnityEngine.Vector3, $end: UnityEngine.Vector3):void;
            /** Draws a line between specified start and end points. * @param start Point in world space where the line should start.
             * @param end Point in world space where the line should end.
             * @param color Color of the line.
             * @param duration How long the line should be visible for.
             * @param depthTest Should the line be obscured by objects closer to the camera?
             */
            public static DrawLine($start: UnityEngine.Vector3, $end: UnityEngine.Vector3, $color: UnityEngine.Color, $duration: number, $depthTest: boolean):void;
            /** Draws a line from start to start + dir in world coordinates. * @param start Point in world space where the ray should start.
             * @param dir Direction and length of the ray.
             * @param color Color of the drawn line.
             * @param duration How long the line will be visible for (in seconds).
             * @param depthTest Should the line be obscured by other objects closer to the camera?
             */
            public static DrawRay($start: UnityEngine.Vector3, $dir: UnityEngine.Vector3, $color: UnityEngine.Color, $duration: number):void;
            /** Draws a line from start to start + dir in world coordinates. * @param start Point in world space where the ray should start.
             * @param dir Direction and length of the ray.
             * @param color Color of the drawn line.
             * @param duration How long the line will be visible for (in seconds).
             * @param depthTest Should the line be obscured by other objects closer to the camera?
             */
            public static DrawRay($start: UnityEngine.Vector3, $dir: UnityEngine.Vector3, $color: UnityEngine.Color):void;
            /** Draws a line from start to start + dir in world coordinates. * @param start Point in world space where the ray should start.
             * @param dir Direction and length of the ray.
             * @param color Color of the drawn line.
             * @param duration How long the line will be visible for (in seconds).
             * @param depthTest Should the line be obscured by other objects closer to the camera?
             */
            public static DrawRay($start: UnityEngine.Vector3, $dir: UnityEngine.Vector3):void;
            /** Draws a line from start to start + dir in world coordinates. * @param start Point in world space where the ray should start.
             * @param dir Direction and length of the ray.
             * @param color Color of the drawn line.
             * @param duration How long the line will be visible for (in seconds).
             * @param depthTest Should the line be obscured by other objects closer to the camera?
             */
            public static DrawRay($start: UnityEngine.Vector3, $dir: UnityEngine.Vector3, $color: UnityEngine.Color, $duration: number, $depthTest: boolean):void;
            
            public static Break():void;
            
            public static DebugBreak():void;
            /** Logs a message to the Unity Console. * @param message String or object to be converted to string representation for display.
             * @param context Object to which the message applies.
             */
            public static Log($message: any):void;
            /** Logs a message to the Unity Console. * @param message String or object to be converted to string representation for display.
             * @param context Object to which the message applies.
             */
            public static Log($message: any, $context: UnityEngine.Object):void;
            /** Logs a formatted message to the Unity Console. * @param format A composite format string.
             * @param args Format arguments.
             * @param context Object to which the message applies.
             * @param logType Type of message e.g. warn or error etc.
             * @param logOptions Option flags to treat the log message special.
             */
            public static LogFormat($format: string, ...args: any[]):void;
            /** Logs a formatted message to the Unity Console. * @param format A composite format string.
             * @param args Format arguments.
             * @param context Object to which the message applies.
             * @param logType Type of message e.g. warn or error etc.
             * @param logOptions Option flags to treat the log message special.
             */
            public static LogFormat($context: UnityEngine.Object, $format: string, ...args: any[]):void;
            /** Logs a formatted message to the Unity Console. * @param format A composite format string.
             * @param args Format arguments.
             * @param context Object to which the message applies.
             * @param logType Type of message e.g. warn or error etc.
             * @param logOptions Option flags to treat the log message special.
             */
            public static LogFormat($logType: UnityEngine.LogType, $logOptions: UnityEngine.LogOption, $context: UnityEngine.Object, $format: string, ...args: any[]):void;
            /** A variant of Debug.Log that logs an error message to the console. * @param message String or object to be converted to string representation for display.
             * @param context Object to which the message applies.
             */
            public static LogError($message: any):void;
            /** A variant of Debug.Log that logs an error message to the console. * @param message String or object to be converted to string representation for display.
             * @param context Object to which the message applies.
             */
            public static LogError($message: any, $context: UnityEngine.Object):void;
            /** Logs a formatted error message to the Unity console. * @param format A composite format string.
             * @param args Format arguments.
             * @param context Object to which the message applies.
             */
            public static LogErrorFormat($format: string, ...args: any[]):void;
            /** Logs a formatted error message to the Unity console. * @param format A composite format string.
             * @param args Format arguments.
             * @param context Object to which the message applies.
             */
            public static LogErrorFormat($context: UnityEngine.Object, $format: string, ...args: any[]):void;
            
            public static ClearDeveloperConsole():void;
            /** A variant of Debug.Log that logs an error message to the console. * @param context Object to which the message applies.
             * @param exception Runtime Exception.
             */
            public static LogException($exception: System.Exception):void;
            /** A variant of Debug.Log that logs an error message to the console. * @param context Object to which the message applies.
             * @param exception Runtime Exception.
             */
            public static LogException($exception: System.Exception, $context: UnityEngine.Object):void;
            /** A variant of Debug.Log that logs a warning message to the console. * @param message String or object to be converted to string representation for display.
             * @param context Object to which the message applies.
             */
            public static LogWarning($message: any):void;
            /** A variant of Debug.Log that logs a warning message to the console. * @param message String or object to be converted to string representation for display.
             * @param context Object to which the message applies.
             */
            public static LogWarning($message: any, $context: UnityEngine.Object):void;
            /** Logs a formatted warning message to the Unity Console. * @param format A composite format string.
             * @param args Format arguments.
             * @param context Object to which the message applies.
             */
            public static LogWarningFormat($format: string, ...args: any[]):void;
            /** Logs a formatted warning message to the Unity Console. * @param format A composite format string.
             * @param args Format arguments.
             * @param context Object to which the message applies.
             */
            public static LogWarningFormat($context: UnityEngine.Object, $format: string, ...args: any[]):void;
            /** Assert a condition and logs an error message to the Unity console on failure. * @param condition Condition you expect to be true.
             * @param context Object to which the message applies.
             * @param message String or object to be converted to string representation for display.
             */
            public static Assert($condition: boolean):void;
            /** Assert a condition and logs an error message to the Unity console on failure. * @param condition Condition you expect to be true.
             * @param context Object to which the message applies.
             * @param message String or object to be converted to string representation for display.
             */
            public static Assert($condition: boolean, $context: UnityEngine.Object):void;
            /** Assert a condition and logs an error message to the Unity console on failure. * @param condition Condition you expect to be true.
             * @param context Object to which the message applies.
             * @param message String or object to be converted to string representation for display.
             */
            public static Assert($condition: boolean, $message: any):void;
            
            public static Assert($condition: boolean, $message: string):void;
            /** Assert a condition and logs an error message to the Unity console on failure. * @param condition Condition you expect to be true.
             * @param context Object to which the message applies.
             * @param message String or object to be converted to string representation for display.
             */
            public static Assert($condition: boolean, $message: any, $context: UnityEngine.Object):void;
            
            public static Assert($condition: boolean, $message: string, $context: UnityEngine.Object):void;
            /** Assert a condition and logs a formatted error message to the Unity console on failure. * @param condition Condition you expect to be true.
             * @param format A composite format string.
             * @param args Format arguments.
             * @param context Object to which the message applies.
             */
            public static AssertFormat($condition: boolean, $format: string, ...args: any[]):void;
            /** Assert a condition and logs a formatted error message to the Unity console on failure. * @param condition Condition you expect to be true.
             * @param format A composite format string.
             * @param args Format arguments.
             * @param context Object to which the message applies.
             */
            public static AssertFormat($condition: boolean, $context: UnityEngine.Object, $format: string, ...args: any[]):void;
            /** A variant of Debug.Log that logs an assertion message to the console. * @param message String or object to be converted to string representation for display.
             * @param context Object to which the message applies.
             */
            public static LogAssertion($message: any):void;
            /** A variant of Debug.Log that logs an assertion message to the console. * @param message String or object to be converted to string representation for display.
             * @param context Object to which the message applies.
             */
            public static LogAssertion($message: any, $context: UnityEngine.Object):void;
            /** Logs a formatted assertion message to the Unity console. * @param format A composite format string.
             * @param args Format arguments.
             * @param context Object to which the message applies.
             */
            public static LogAssertionFormat($format: string, ...args: any[]):void;
            /** Logs a formatted assertion message to the Unity console. * @param format A composite format string.
             * @param args Format arguments.
             * @param context Object to which the message applies.
             */
            public static LogAssertionFormat($context: UnityEngine.Object, $format: string, ...args: any[]):void;
            
            public constructor();
            
        }
        
        
        interface ILogger extends UnityEngine.ILogHandler{ 
            
        }
        
        
        interface ILogHandler{ 
            
        }
        
        /** Representation of 3D vectors and points. */
        class Vector3 extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Vector3>{ 
            
        }
        
        /** Representation of RGBA colors. */
        class Color extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Color>{ 
            
        }
        
        /** Base class for all objects Unity can reference. */
        class Object extends System.Object{ 
            
        }
        
        /** The type of the log message in Debug.unityLogger.Log or delegate registered with Application.RegisterLogCallback. */
        enum LogType{ Error = 0, Assert = 1, Warning = 2, Log = 3, Exception = 4 }
        
        /** Option flags for specifying special treatment of a log message. */
        enum LogOption{ None = 0, NoStacktrace = 1 }
        
        /** Provides an interface to get time information from Unity. */
        class Time extends System.Object{ 
            /** The time at the beginning of this frame (Read Only). */
            public static get time(): number;
            
            /** The double precision time at the beginning of this frame (Read Only). This is the time in seconds since the start of the game. */
            public static get timeAsDouble(): number;
            
            /** The time since this frame started (Read Only). This is the time in seconds since the last non-additive scene has finished loading. */
            public static get timeSinceLevelLoad(): number;
            
            /** The double precision time since this frame started (Read Only). This is the time in seconds since the last non-additive scene has finished loading. */
            public static get timeSinceLevelLoadAsDouble(): number;
            
            /** The interval in seconds from the last frame to the current one (Read Only). */
            public static get deltaTime(): number;
            
            /** The time since the last MonoBehaviour.FixedUpdate started (Read Only). This is the time in seconds since the start of the game. */
            public static get fixedTime(): number;
            
            /** The double precision time since the last MonoBehaviour.FixedUpdate started (Read Only). This is the time in seconds since the start of the game. */
            public static get fixedTimeAsDouble(): number;
            
            /** The timeScale-independent time for this frame (Read Only). This is the time in seconds since the start of the game. */
            public static get unscaledTime(): number;
            
            /** The double precision timeScale-independent time for this frame (Read Only). This is the time in seconds since the start of the game. */
            public static get unscaledTimeAsDouble(): number;
            
            /** The timeScale-independent time at the beginning of the last MonoBehaviour.FixedUpdate phase (Read Only). This is the time in seconds since the start of the game. */
            public static get fixedUnscaledTime(): number;
            
            /** The double precision timeScale-independent time at the beginning of the last MonoBehaviour.FixedUpdate (Read Only). This is the time in seconds since the start of the game. */
            public static get fixedUnscaledTimeAsDouble(): number;
            
            /** The timeScale-independent interval in seconds from the last frame to the current one (Read Only). */
            public static get unscaledDeltaTime(): number;
            
            /** The timeScale-independent interval in seconds from the last MonoBehaviour.FixedUpdate phase to the current one (Read Only). */
            public static get fixedUnscaledDeltaTime(): number;
            
            /** The interval in seconds at which physics and other fixed frame rate updates (like MonoBehaviour's MonoBehaviour.FixedUpdate) are performed. */
            public static get fixedDeltaTime(): number;
            public static set fixedDeltaTime(value: number);
            /** The maximum value of Time.deltaTime in any given frame. This is a time in seconds that limits the increase of Time.time between two frames. */
            public static get maximumDeltaTime(): number;
            public static set maximumDeltaTime(value: number);
            /** A smoothed out Time.deltaTime (Read Only). */
            public static get smoothDeltaTime(): number;
            
            /** The maximum time a frame can spend on particle updates. If the frame takes longer than this, then updates are split into multiple smaller updates. */
            public static get maximumParticleDeltaTime(): number;
            public static set maximumParticleDeltaTime(value: number);
            /** The scale at which time passes. */
            public static get timeScale(): number;
            public static set timeScale(value: number);
            /** The total number of frames since the start of the game (Read Only). */
            public static get frameCount(): number;
            
            
            public static get renderedFrameCount(): number;
            
            /** The real time in seconds since the game started (Read Only). */
            public static get realtimeSinceStartup(): number;
            
            /** The real time in seconds since the game started (Read Only). Double precision version of Time.realtimeSinceStartup.  */
            public static get realtimeSinceStartupAsDouble(): number;
            
            /** Slows your application’s playback time to allow Unity to save screenshots in between frames. */
            public static get captureDeltaTime(): number;
            public static set captureDeltaTime(value: number);
            /** The reciprocal of Time.captureDeltaTime. */
            public static get captureFramerate(): number;
            public static set captureFramerate(value: number);
            /** Returns true if called inside a fixed time step callback (like MonoBehaviour's MonoBehaviour.FixedUpdate), otherwise returns false. */
            public static get inFixedTimeStep(): boolean;
            
            
            public constructor();
            
        }
        
        /** Base class for all entities in Unity Scenes. */
        class GameObject extends UnityEngine.Object{ 
            /** The Transform attached to this GameObject. */
            public get transform(): UnityEngine.Transform;
            
            /** The layer the GameObject is in. */
            public get layer(): number;
            public set layer(value: number);
            /** The local active state of this GameObject. (Read Only) */
            public get activeSelf(): boolean;
            
            /** Defines whether the GameObject is active in the Scene. */
            public get activeInHierarchy(): boolean;
            
            /** Gets and sets the GameObject's StaticEditorFlags. */
            public get isStatic(): boolean;
            public set isStatic(value: boolean);
            /** The tag of this game object. */
            public get tag(): string;
            public set tag(value: string);
            /** Scene that the GameObject is part of. */
            public get scene(): UnityEngine.SceneManagement.Scene;
            
            /** Scene culling mask Unity uses to determine which scene to render the GameObject in. */
            public get sceneCullingMask(): bigint;
            
            
            public get gameObject(): UnityEngine.GameObject;
            
            /** Creates a game object with a primitive mesh renderer and appropriate collider. * @param type The type of primitive object to create.
             */
            public static CreatePrimitive($type: UnityEngine.PrimitiveType):UnityEngine.GameObject;
            /** Returns the component of Type type if the game object has one attached, null if it doesn't. * @param type The type of Component to retrieve.
             */
            public GetComponent($type: System.Type):UnityEngine.Component;
            /** Returns the component with name type if the GameObject has one attached, null if it doesn't. * @param type The type of Component to retrieve.
             */
            public GetComponent($type: string):UnityEngine.Component;
            /** Returns the component of Type type in the GameObject or any of its children using depth first search.
             * @param type The type of Component to retrieve.
             * @returns A component of the matching type, if found. 
             */
            public GetComponentInChildren($type: System.Type, $includeInactive: boolean):UnityEngine.Component;
            /** Returns the component of Type type in the GameObject or any of its children using depth first search.
             * @param type The type of Component to retrieve.
             * @returns A component of the matching type, if found. 
             */
            public GetComponentInChildren($type: System.Type):UnityEngine.Component;
            /** Retrieves the component of Type type in the GameObject or any of its parents.
             * @param type Type of component to find.
             * @returns Returns a component if a component matching the type is found. Returns null otherwise. 
             */
            public GetComponentInParent($type: System.Type, $includeInactive: boolean):UnityEngine.Component;
            /** Retrieves the component of Type type in the GameObject or any of its parents.
             * @param type Type of component to find.
             * @returns Returns a component if a component matching the type is found. Returns null otherwise. 
             */
            public GetComponentInParent($type: System.Type):UnityEngine.Component;
            /** Returns all components of Type type in the GameObject. * @param type The type of component to retrieve.
             */
            public GetComponents($type: System.Type):System.Array$1<UnityEngine.Component>;
            
            public GetComponents($type: System.Type, $results: System.Collections.Generic.List$1<UnityEngine.Component>):void;
            /** Returns all components of Type type in the GameObject or any of its children. * @param type The type of Component to retrieve.
             * @param includeInactive Should Components on inactive GameObjects be included in the found set?
             */
            public GetComponentsInChildren($type: System.Type):System.Array$1<UnityEngine.Component>;
            /** Returns all components of Type type in the GameObject or any of its children. * @param type The type of Component to retrieve.
             * @param includeInactive Should Components on inactive GameObjects be included in the found set?
             */
            public GetComponentsInChildren($type: System.Type, $includeInactive: boolean):System.Array$1<UnityEngine.Component>;
            
            public GetComponentsInParent($type: System.Type):System.Array$1<UnityEngine.Component>;
            /** Returns all components of Type type in the GameObject or any of its parents. * @param type The type of Component to retrieve.
             * @param includeInactive Should inactive Components be included in the found set?
             */
            public GetComponentsInParent($type: System.Type, $includeInactive: boolean):System.Array$1<UnityEngine.Component>;
            /** Gets the component of the specified type, if it exists.
             * @param type The type of component to retrieve.
             * @param component The output argument that will contain the component or null.
             * @returns Returns true if the component is found, false otherwise. 
             */
            public TryGetComponent($type: System.Type, $component: $Ref<UnityEngine.Component>):boolean;
            /** Returns one active GameObject tagged tag. Returns null if no GameObject was found. * @param tag The tag to search for.
             */
            public static FindWithTag($tag: string):UnityEngine.GameObject;
            
            public SendMessageUpwards($methodName: string, $options: UnityEngine.SendMessageOptions):void;
            
            public SendMessage($methodName: string, $options: UnityEngine.SendMessageOptions):void;
            
            public BroadcastMessage($methodName: string, $options: UnityEngine.SendMessageOptions):void;
            /** Adds a component class of type componentType to the game object. C# Users can use a generic version. */
            public AddComponent($componentType: System.Type):UnityEngine.Component;
            /** ActivatesDeactivates the GameObject, depending on the given true or false/ value. * @param value Activate or deactivate the object, where true activates the GameObject and false deactivates the GameObject.
             */
            public SetActive($value: boolean):void;
            /** Is this game object tagged with tag ? * @param tag The tag to compare.
             */
            public CompareTag($tag: string):boolean;
            
            public static FindGameObjectWithTag($tag: string):UnityEngine.GameObject;
            /** Returns an array of active GameObjects tagged tag. Returns empty array if no GameObject was found. * @param tag The name of the tag to search GameObjects for.
             */
            public static FindGameObjectsWithTag($tag: string):System.Array$1<UnityEngine.GameObject>;
            /** Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour. * @param methodName The name of the method to call.
             * @param value An optional parameter value to pass to the called method.
             * @param options Should an error be raised if the method doesn't exist on the target object?
             */
            public SendMessageUpwards($methodName: string, $value: any, $options: UnityEngine.SendMessageOptions):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour. * @param methodName The name of the method to call.
             * @param value An optional parameter value to pass to the called method.
             * @param options Should an error be raised if the method doesn't exist on the target object?
             */
            public SendMessageUpwards($methodName: string, $value: any):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour. * @param methodName The name of the method to call.
             * @param value An optional parameter value to pass to the called method.
             * @param options Should an error be raised if the method doesn't exist on the target object?
             */
            public SendMessageUpwards($methodName: string):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object. * @param methodName The name of the method to call.
             * @param value An optional parameter value to pass to the called method.
             * @param options Should an error be raised if the method doesn't exist on the target object?
             */
            public SendMessage($methodName: string, $value: any, $options: UnityEngine.SendMessageOptions):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object. * @param methodName The name of the method to call.
             * @param value An optional parameter value to pass to the called method.
             * @param options Should an error be raised if the method doesn't exist on the target object?
             */
            public SendMessage($methodName: string, $value: any):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object. * @param methodName The name of the method to call.
             * @param value An optional parameter value to pass to the called method.
             * @param options Should an error be raised if the method doesn't exist on the target object?
             */
            public SendMessage($methodName: string):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object or any of its children. */
            public BroadcastMessage($methodName: string, $parameter: any, $options: UnityEngine.SendMessageOptions):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object or any of its children. */
            public BroadcastMessage($methodName: string, $parameter: any):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object or any of its children. */
            public BroadcastMessage($methodName: string):void;
            /** Finds a GameObject by name and returns it. */
            public static Find($name: string):UnityEngine.GameObject;
            
            public constructor($name: string);
            
            public constructor();
            
            public constructor($name: string, ...components: System.Type[]);
            
        }
        
        /** The various primitives that can be created using the GameObject.CreatePrimitive function. */
        enum PrimitiveType{ Sphere = 0, Capsule = 1, Cylinder = 2, Cube = 3, Plane = 4, Quad = 5 }
        
        /** Base class for everything attached to GameObjects. */
        class Component extends UnityEngine.Object{ 
            /** The Transform attached to this GameObject. */
            public get transform(): UnityEngine.Transform;
            
            /** The game object this component is attached to. A component is always attached to a game object. */
            public get gameObject(): UnityEngine.GameObject;
            
            /** The tag of this game object. */
            public get tag(): string;
            public set tag(value: string);
            /** Returns the component of type if the GameObject has one attached.
             * @param type The type of Component to retrieve.
             * @returns A Component of the matching type, otherwise null if no Component is found. 
             */
            public GetComponent($type: System.Type):UnityEngine.Component;
            /** Gets the component of the specified type, if it exists.
             * @param type The type of the component to retrieve.
             * @param component The output argument that will contain the component or null.
             * @returns Returns true if the component is found, false otherwise. 
             */
            public TryGetComponent($type: System.Type, $component: $Ref<UnityEngine.Component>):boolean;
            /** To improve the performance of your code, consider using GetComponent with a type instead of a string.
             * @param type The name of the type of Component to get.
             * @returns A Component of the matching type, otherwise null if no Component is found. 
             */
            public GetComponent($type: string):UnityEngine.Component;
            /** Returns the Component of type in the GameObject or any of its children using depth first search.
             * @param t The type of Component to retrieve.
             * @param includeInactive Should Components on inactive GameObjects be included in the found set?
             * @returns A Component of the matching type, otherwise null if no Component is found. 
             */
            public GetComponentInChildren($t: System.Type, $includeInactive: boolean):UnityEngine.Component;
            /** Returns the Component of type in the GameObject or any of its children using depth first search.
             * @param t The type of Component to retrieve.
             * @param includeInactive Should Components on inactive GameObjects be included in the found set?
             * @returns A Component of the matching type, otherwise null if no Component is found. 
             */
            public GetComponentInChildren($t: System.Type):UnityEngine.Component;
            /** Returns all components of Type type in the GameObject or any of its children. Works recursively. * @param t The type of Component to retrieve.
             * @param includeInactive Should Components on inactive GameObjects be included in the found set. includeInactive decides which children of the GameObject will be searched.  The GameObject that you call GetComponentsInChildren on is always searched regardless. Default is false.
             */
            public GetComponentsInChildren($t: System.Type, $includeInactive: boolean):System.Array$1<UnityEngine.Component>;
            
            public GetComponentsInChildren($t: System.Type):System.Array$1<UnityEngine.Component>;
            /** Returns the Component of type in the GameObject or any of its parents.
             * @param t The type of Component to retrieve.
             * @param includeInactive Should Components on inactive GameObjects be included in the found set?
             * @returns A Component of the matching type, otherwise null if no Component is found. 
             */
            public GetComponentInParent($t: System.Type, $includeInactive: boolean):UnityEngine.Component;
            /** Returns the Component of type in the GameObject or any of its parents.
             * @param t The type of Component to retrieve.
             * @param includeInactive Should Components on inactive GameObjects be included in the found set?
             * @returns A Component of the matching type, otherwise null if no Component is found. 
             */
            public GetComponentInParent($t: System.Type):UnityEngine.Component;
            /** Returns all components of Type type in the GameObject or any of its parents. * @param t The type of Component to retrieve.
             * @param includeInactive Should inactive Components be included in the found set?
             */
            public GetComponentsInParent($t: System.Type, $includeInactive: boolean):System.Array$1<UnityEngine.Component>;
            
            public GetComponentsInParent($t: System.Type):System.Array$1<UnityEngine.Component>;
            /** Returns all components of Type type in the GameObject. * @param type The type of Component to retrieve.
             */
            public GetComponents($type: System.Type):System.Array$1<UnityEngine.Component>;
            
            public GetComponents($type: System.Type, $results: System.Collections.Generic.List$1<UnityEngine.Component>):void;
            /** Checks the GameObject's tag against the defined tag.
             * @param tag The tag to compare.
             * @returns Returns true if GameObject has same tag. Returns false otherwise. 
             */
            public CompareTag($tag: string):boolean;
            /** Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour. * @param methodName Name of method to call.
             * @param value Optional parameter value for the method.
             * @param options Should an error be raised if the method does not exist on the target object?
             */
            public SendMessageUpwards($methodName: string, $value: any, $options: UnityEngine.SendMessageOptions):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour. * @param methodName Name of method to call.
             * @param value Optional parameter value for the method.
             * @param options Should an error be raised if the method does not exist on the target object?
             */
            public SendMessageUpwards($methodName: string, $value: any):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour. * @param methodName Name of method to call.
             * @param value Optional parameter value for the method.
             * @param options Should an error be raised if the method does not exist on the target object?
             */
            public SendMessageUpwards($methodName: string):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour. * @param methodName Name of method to call.
             * @param value Optional parameter value for the method.
             * @param options Should an error be raised if the method does not exist on the target object?
             */
            public SendMessageUpwards($methodName: string, $options: UnityEngine.SendMessageOptions):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object. * @param methodName Name of the method to call.
             * @param value Optional parameter for the method.
             * @param options Should an error be raised if the target object doesn't implement the method for the message?
             */
            public SendMessage($methodName: string, $value: any):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object. * @param methodName Name of the method to call.
             * @param value Optional parameter for the method.
             * @param options Should an error be raised if the target object doesn't implement the method for the message?
             */
            public SendMessage($methodName: string):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object. * @param methodName Name of the method to call.
             * @param value Optional parameter for the method.
             * @param options Should an error be raised if the target object doesn't implement the method for the message?
             */
            public SendMessage($methodName: string, $value: any, $options: UnityEngine.SendMessageOptions):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object. * @param methodName Name of the method to call.
             * @param value Optional parameter for the method.
             * @param options Should an error be raised if the target object doesn't implement the method for the message?
             */
            public SendMessage($methodName: string, $options: UnityEngine.SendMessageOptions):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object or any of its children. * @param methodName Name of the method to call.
             * @param parameter Optional parameter to pass to the method (can be any value).
             * @param options Should an error be raised if the method does not exist for a given target object?
             */
            public BroadcastMessage($methodName: string, $parameter: any, $options: UnityEngine.SendMessageOptions):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object or any of its children. * @param methodName Name of the method to call.
             * @param parameter Optional parameter to pass to the method (can be any value).
             * @param options Should an error be raised if the method does not exist for a given target object?
             */
            public BroadcastMessage($methodName: string, $parameter: any):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object or any of its children. * @param methodName Name of the method to call.
             * @param parameter Optional parameter to pass to the method (can be any value).
             * @param options Should an error be raised if the method does not exist for a given target object?
             */
            public BroadcastMessage($methodName: string):void;
            /** Calls the method named methodName on every MonoBehaviour in this game object or any of its children. * @param methodName Name of the method to call.
             * @param parameter Optional parameter to pass to the method (can be any value).
             * @param options Should an error be raised if the method does not exist for a given target object?
             */
            public BroadcastMessage($methodName: string, $options: UnityEngine.SendMessageOptions):void;
            
            public constructor();
            
        }
        
        /** Options for how to send a message. */
        enum SendMessageOptions{ RequireReceiver = 0, DontRequireReceiver = 1 }
        
        /** Position, rotation and scale of an object. */
        class Transform extends UnityEngine.Component implements System.Collections.IEnumerable{ 
            /** The world space position of the Transform. */
            public get position(): UnityEngine.Vector3;
            public set position(value: UnityEngine.Vector3);
            /** Position of the transform relative to the parent transform. */
            public get localPosition(): UnityEngine.Vector3;
            public set localPosition(value: UnityEngine.Vector3);
            /** The rotation as Euler angles in degrees. */
            public get eulerAngles(): UnityEngine.Vector3;
            public set eulerAngles(value: UnityEngine.Vector3);
            /** The rotation as Euler angles in degrees relative to the parent transform's rotation. */
            public get localEulerAngles(): UnityEngine.Vector3;
            public set localEulerAngles(value: UnityEngine.Vector3);
            /** The red axis of the transform in world space. */
            public get right(): UnityEngine.Vector3;
            public set right(value: UnityEngine.Vector3);
            /** The green axis of the transform in world space. */
            public get up(): UnityEngine.Vector3;
            public set up(value: UnityEngine.Vector3);
            /** Returns a normalized vector representing the blue axis of the transform in world space. */
            public get forward(): UnityEngine.Vector3;
            public set forward(value: UnityEngine.Vector3);
            /** A Quaternion that stores the rotation of the Transform in world space. */
            public get rotation(): UnityEngine.Quaternion;
            public set rotation(value: UnityEngine.Quaternion);
            /** The rotation of the transform relative to the transform rotation of the parent. */
            public get localRotation(): UnityEngine.Quaternion;
            public set localRotation(value: UnityEngine.Quaternion);
            /** The scale of the transform relative to the GameObjects parent. */
            public get localScale(): UnityEngine.Vector3;
            public set localScale(value: UnityEngine.Vector3);
            /** The parent of the transform. */
            public get parent(): UnityEngine.Transform;
            public set parent(value: UnityEngine.Transform);
            /** Matrix that transforms a point from world space into local space (Read Only). */
            public get worldToLocalMatrix(): UnityEngine.Matrix4x4;
            
            /** Matrix that transforms a point from local space into world space (Read Only). */
            public get localToWorldMatrix(): UnityEngine.Matrix4x4;
            
            /** Returns the topmost transform in the hierarchy. */
            public get root(): UnityEngine.Transform;
            
            /** The number of children the parent Transform has. */
            public get childCount(): number;
            
            /** The global scale of the object (Read Only). */
            public get lossyScale(): UnityEngine.Vector3;
            
            /** Has the transform changed since the last time the flag was set to 'false'? */
            public get hasChanged(): boolean;
            public set hasChanged(value: boolean);
            /** The transform capacity of the transform's hierarchy data structure. */
            public get hierarchyCapacity(): number;
            public set hierarchyCapacity(value: number);
            /** The number of transforms in the transform's hierarchy data structure. */
            public get hierarchyCount(): number;
            
            /** Set the parent of the transform. * @param parent The parent Transform to use.
             * @param worldPositionStays If true, the parent-relative position, scale and rotation are modified such that the object keeps the same world space position, rotation and scale as before.
             */
            public SetParent($p: UnityEngine.Transform):void;
            /** Set the parent of the transform. * @param parent The parent Transform to use.
             * @param worldPositionStays If true, the parent-relative position, scale and rotation are modified such that the object keeps the same world space position, rotation and scale as before.
             */
            public SetParent($parent: UnityEngine.Transform, $worldPositionStays: boolean):void;
            /** Sets the world space position and rotation of the Transform component. */
            public SetPositionAndRotation($position: UnityEngine.Vector3, $rotation: UnityEngine.Quaternion):void;
            /** Moves the transform in the direction and distance of translation. */
            public Translate($translation: UnityEngine.Vector3, $relativeTo: UnityEngine.Space):void;
            /** Moves the transform in the direction and distance of translation. */
            public Translate($translation: UnityEngine.Vector3):void;
            /** Moves the transform by x along the x axis, y along the y axis, and z along the z axis. */
            public Translate($x: number, $y: number, $z: number, $relativeTo: UnityEngine.Space):void;
            /** Moves the transform by x along the x axis, y along the y axis, and z along the z axis. */
            public Translate($x: number, $y: number, $z: number):void;
            /** Moves the transform in the direction and distance of translation. */
            public Translate($translation: UnityEngine.Vector3, $relativeTo: UnityEngine.Transform):void;
            /** Moves the transform by x along the x axis, y along the y axis, and z along the z axis. */
            public Translate($x: number, $y: number, $z: number, $relativeTo: UnityEngine.Transform):void;
            /** Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x degrees around the x-axis, and eulerAngles.y degrees around the y-axis (in that order). * @param eulers The rotation to apply in euler angles.
             * @param relativeTo Determines whether to rotate the GameObject either locally to  the GameObject or relative to the Scene in world space.
             */
            public Rotate($eulers: UnityEngine.Vector3, $relativeTo: UnityEngine.Space):void;
            /** Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x degrees around the x-axis, and eulerAngles.y degrees around the y-axis (in that order). * @param eulers The rotation to apply in euler angles.
             */
            public Rotate($eulers: UnityEngine.Vector3):void;
            /** The implementation of this method applies a rotation of zAngle degrees around the z axis, xAngle degrees around the x axis, and yAngle degrees around the y axis (in that order). * @param relativeTo Determines whether to rotate the GameObject either locally to the GameObject or relative to the Scene in world space.
             * @param xAngle Degrees to rotate the GameObject around the X axis.
             * @param yAngle Degrees to rotate the GameObject around the Y axis.
             * @param zAngle Degrees to rotate the GameObject around the Z axis.
             */
            public Rotate($xAngle: number, $yAngle: number, $zAngle: number, $relativeTo: UnityEngine.Space):void;
            /** The implementation of this method applies a rotation of zAngle degrees around the z axis, xAngle degrees around the x axis, and yAngle degrees around the y axis (in that order). * @param xAngle Degrees to rotate the GameObject around the X axis.
             * @param yAngle Degrees to rotate the GameObject around the Y axis.
             * @param zAngle Degrees to rotate the GameObject around the Z axis.
             */
            public Rotate($xAngle: number, $yAngle: number, $zAngle: number):void;
            /** Rotates the object around the given axis by the number of degrees defined by the given angle. * @param angle The degrees of rotation to apply.
             * @param axis The axis to apply rotation to.
             * @param relativeTo Determines whether to rotate the GameObject either locally to the GameObject or relative to the Scene in world space.
             */
            public Rotate($axis: UnityEngine.Vector3, $angle: number, $relativeTo: UnityEngine.Space):void;
            /** Rotates the object around the given axis by the number of degrees defined by the given angle. * @param axis The axis to apply rotation to.
             * @param angle The degrees of rotation to apply.
             */
            public Rotate($axis: UnityEngine.Vector3, $angle: number):void;
            /** Rotates the transform about axis passing through point in world coordinates by angle degrees. */
            public RotateAround($point: UnityEngine.Vector3, $axis: UnityEngine.Vector3, $angle: number):void;
            /** Rotates the transform so the forward vector points at target's current position. * @param target Object to point towards.
             * @param worldUp Vector specifying the upward direction.
             */
            public LookAt($target: UnityEngine.Transform, $worldUp: UnityEngine.Vector3):void;
            /** Rotates the transform so the forward vector points at target's current position. * @param target Object to point towards.
             * @param worldUp Vector specifying the upward direction.
             */
            public LookAt($target: UnityEngine.Transform):void;
            /** Rotates the transform so the forward vector points at worldPosition. * @param worldPosition Point to look at.
             * @param worldUp Vector specifying the upward direction.
             */
            public LookAt($worldPosition: UnityEngine.Vector3, $worldUp: UnityEngine.Vector3):void;
            /** Rotates the transform so the forward vector points at worldPosition. * @param worldPosition Point to look at.
             * @param worldUp Vector specifying the upward direction.
             */
            public LookAt($worldPosition: UnityEngine.Vector3):void;
            /** Transforms direction from local space to world space. */
            public TransformDirection($direction: UnityEngine.Vector3):UnityEngine.Vector3;
            /** Transforms direction x, y, z from local space to world space. */
            public TransformDirection($x: number, $y: number, $z: number):UnityEngine.Vector3;
            /** Transforms a direction from world space to local space. The opposite of Transform.TransformDirection. */
            public InverseTransformDirection($direction: UnityEngine.Vector3):UnityEngine.Vector3;
            /** Transforms the direction x, y, z from world space to local space. The opposite of Transform.TransformDirection. */
            public InverseTransformDirection($x: number, $y: number, $z: number):UnityEngine.Vector3;
            /** Transforms vector from local space to world space. */
            public TransformVector($vector: UnityEngine.Vector3):UnityEngine.Vector3;
            /** Transforms vector x, y, z from local space to world space. */
            public TransformVector($x: number, $y: number, $z: number):UnityEngine.Vector3;
            /** Transforms a vector from world space to local space. The opposite of Transform.TransformVector. */
            public InverseTransformVector($vector: UnityEngine.Vector3):UnityEngine.Vector3;
            /** Transforms the vector x, y, z from world space to local space. The opposite of Transform.TransformVector. */
            public InverseTransformVector($x: number, $y: number, $z: number):UnityEngine.Vector3;
            /** Transforms position from local space to world space. */
            public TransformPoint($position: UnityEngine.Vector3):UnityEngine.Vector3;
            /** Transforms the position x, y, z from local space to world space. */
            public TransformPoint($x: number, $y: number, $z: number):UnityEngine.Vector3;
            /** Transforms position from world space to local space. */
            public InverseTransformPoint($position: UnityEngine.Vector3):UnityEngine.Vector3;
            /** Transforms the position x, y, z from world space to local space. The opposite of Transform.TransformPoint. */
            public InverseTransformPoint($x: number, $y: number, $z: number):UnityEngine.Vector3;
            
            public DetachChildren():void;
            
            public SetAsFirstSibling():void;
            
            public SetAsLastSibling():void;
            /** Sets the sibling index. * @param index Index to set.
             */
            public SetSiblingIndex($index: number):void;
            
            public GetSiblingIndex():number;
            /** Finds a child by name n and returns it.
             * @param n Name of child to be found.
             * @returns The found child transform. Null if child with matching name isn't found. 
             */
            public Find($n: string):UnityEngine.Transform;
            /** Is this transform a child of parent? */
            public IsChildOf($parent: UnityEngine.Transform):boolean;
            
            public GetEnumerator():System.Collections.IEnumerator;
            /** Returns a transform child by index.
             * @param index Index of the child transform to return. Must be smaller than Transform.childCount.
             * @returns Transform child by index. 
             */
            public GetChild($index: number):UnityEngine.Transform;
            
        }
        
        /** Quaternions are used to represent rotations. */
        class Quaternion extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Quaternion>{ 
            
        }
        
        /** A standard 4x4 transformation matrix. */
        class Matrix4x4 extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Matrix4x4>{ 
            
        }
        
        /** The coordinate space in which to operate. */
        enum Space{ World = 0, Self = 1 }
        
        /** A Camera is a device through which the player views the world. */
        class Camera extends UnityEngine.Behaviour{ 
            /** Delegate that you can use to execute custom code before a Camera culls the scene. */
            public static onPreCull: UnityEngine.Camera.CameraCallback;
            /** Delegate that you can use to execute custom code before a Camera renders the scene. */
            public static onPreRender: UnityEngine.Camera.CameraCallback;
            /** Delegate that you can use to execute custom code after a Camera renders the scene. */
            public static onPostRender: UnityEngine.Camera.CameraCallback;
            /** The distance of the near clipping plane from the the Camera, in world units. */
            public get nearClipPlane(): number;
            public set nearClipPlane(value: number);
            /** The distance of the far clipping plane from the Camera, in world units. */
            public get farClipPlane(): number;
            public set farClipPlane(value: number);
            /** The vertical field of view of the Camera, in degrees. */
            public get fieldOfView(): number;
            public set fieldOfView(value: number);
            /** The rendering path that should be used, if possible. */
            public get renderingPath(): UnityEngine.RenderingPath;
            public set renderingPath(value: UnityEngine.RenderingPath);
            /** The rendering path that is currently being used (Read Only). */
            public get actualRenderingPath(): UnityEngine.RenderingPath;
            
            /** High dynamic range rendering. */
            public get allowHDR(): boolean;
            public set allowHDR(value: boolean);
            /** MSAA rendering. */
            public get allowMSAA(): boolean;
            public set allowMSAA(value: boolean);
            /** Dynamic Resolution Scaling. */
            public get allowDynamicResolution(): boolean;
            public set allowDynamicResolution(value: boolean);
            /** Should camera rendering be forced into a RenderTexture. */
            public get forceIntoRenderTexture(): boolean;
            public set forceIntoRenderTexture(value: boolean);
            /** Camera's half-size when in orthographic mode. */
            public get orthographicSize(): number;
            public set orthographicSize(value: number);
            /** Is the camera orthographic (true) or perspective (false)? */
            public get orthographic(): boolean;
            public set orthographic(value: boolean);
            /** Opaque object sorting mode. */
            public get opaqueSortMode(): UnityEngine.Rendering.OpaqueSortMode;
            public set opaqueSortMode(value: UnityEngine.Rendering.OpaqueSortMode);
            /** Transparent object sorting mode. */
            public get transparencySortMode(): UnityEngine.TransparencySortMode;
            public set transparencySortMode(value: UnityEngine.TransparencySortMode);
            /** An axis that describes the direction along which the distances of objects are measured for the purpose of sorting. */
            public get transparencySortAxis(): UnityEngine.Vector3;
            public set transparencySortAxis(value: UnityEngine.Vector3);
            /** Camera's depth in the camera rendering order. */
            public get depth(): number;
            public set depth(value: number);
            /** The aspect ratio (width divided by height). */
            public get aspect(): number;
            public set aspect(value: number);
            /** Get the world-space speed of the camera (Read Only). */
            public get velocity(): UnityEngine.Vector3;
            
            /** This is used to render parts of the Scene selectively. */
            public get cullingMask(): number;
            public set cullingMask(value: number);
            /** Mask to select which layers can trigger events on the camera. */
            public get eventMask(): number;
            public set eventMask(value: number);
            /** How to perform per-layer culling for a Camera. */
            public get layerCullSpherical(): boolean;
            public set layerCullSpherical(value: boolean);
            /** Identifies what kind of camera this is, using the CameraType enum. */
            public get cameraType(): UnityEngine.CameraType;
            public set cameraType(value: UnityEngine.CameraType);
            /** Sets the culling maks used to determine which objects from which Scenes to draw.
            See EditorSceneManager.SetSceneCullingMask. */
            public get overrideSceneCullingMask(): bigint;
            public set overrideSceneCullingMask(value: bigint);
            /** Per-layer culling distances. */
            public get layerCullDistances(): System.Array$1<number>;
            public set layerCullDistances(value: System.Array$1<number>);
            /** Whether or not the Camera will use occlusion culling during rendering. */
            public get useOcclusionCulling(): boolean;
            public set useOcclusionCulling(value: boolean);
            /** Sets a custom matrix for the camera to use for all culling queries. */
            public get cullingMatrix(): UnityEngine.Matrix4x4;
            public set cullingMatrix(value: UnityEngine.Matrix4x4);
            /** The color with which the screen will be cleared. */
            public get backgroundColor(): UnityEngine.Color;
            public set backgroundColor(value: UnityEngine.Color);
            /** How the camera clears the background. */
            public get clearFlags(): UnityEngine.CameraClearFlags;
            public set clearFlags(value: UnityEngine.CameraClearFlags);
            /** How and if camera generates a depth texture. */
            public get depthTextureMode(): UnityEngine.DepthTextureMode;
            public set depthTextureMode(value: UnityEngine.DepthTextureMode);
            /** Should the camera clear the stencil buffer after the deferred light pass? */
            public get clearStencilAfterLightingPass(): boolean;
            public set clearStencilAfterLightingPass(value: boolean);
            /** Enable [UsePhysicalProperties] to use physical camera properties to compute the field of view and the frustum. */
            public get usePhysicalProperties(): boolean;
            public set usePhysicalProperties(value: boolean);
            /** The size of the camera sensor, expressed in millimeters. */
            public get sensorSize(): UnityEngine.Vector2;
            public set sensorSize(value: UnityEngine.Vector2);
            /** The lens offset of the camera. The lens shift is relative to the sensor size. For example, a lens shift of 0.5 offsets the sensor by half its horizontal size. */
            public get lensShift(): UnityEngine.Vector2;
            public set lensShift(value: UnityEngine.Vector2);
            /** The camera focal length, expressed in millimeters. To use this property, enable UsePhysicalProperties. */
            public get focalLength(): number;
            public set focalLength(value: number);
            /** There are two gates for a camera, the sensor gate and the resolution gate. The physical camera sensor gate is defined by the sensorSize property, the resolution gate is defined by the render target area. */
            public get gateFit(): UnityEngine.Camera.GateFitMode;
            public set gateFit(value: UnityEngine.Camera.GateFitMode);
            /** Where on the screen is the camera rendered in normalized coordinates. */
            public get rect(): UnityEngine.Rect;
            public set rect(value: UnityEngine.Rect);
            /** Where on the screen is the camera rendered in pixel coordinates. */
            public get pixelRect(): UnityEngine.Rect;
            public set pixelRect(value: UnityEngine.Rect);
            /** How wide is the camera in pixels (not accounting for dynamic resolution scaling) (Read Only). */
            public get pixelWidth(): number;
            
            /** How tall is the camera in pixels (not accounting for dynamic resolution scaling) (Read Only). */
            public get pixelHeight(): number;
            
            /** How wide is the camera in pixels (accounting for dynamic resolution scaling) (Read Only). */
            public get scaledPixelWidth(): number;
            
            /** How tall is the camera in pixels (accounting for dynamic resolution scaling) (Read Only). */
            public get scaledPixelHeight(): number;
            
            /** Destination render texture. */
            public get targetTexture(): UnityEngine.RenderTexture;
            public set targetTexture(value: UnityEngine.RenderTexture);
            /** Gets the temporary RenderTexture target for this Camera. */
            public get activeTexture(): UnityEngine.RenderTexture;
            
            /** Set the target display for this Camera. */
            public get targetDisplay(): number;
            public set targetDisplay(value: number);
            /** Matrix that transforms from camera space to world space (Read Only). */
            public get cameraToWorldMatrix(): UnityEngine.Matrix4x4;
            
            /** Matrix that transforms from world to camera space. */
            public get worldToCameraMatrix(): UnityEngine.Matrix4x4;
            public set worldToCameraMatrix(value: UnityEngine.Matrix4x4);
            /** Set a custom projection matrix. */
            public get projectionMatrix(): UnityEngine.Matrix4x4;
            public set projectionMatrix(value: UnityEngine.Matrix4x4);
            /** Get or set the raw projection matrix with no camera offset (no jittering). */
            public get nonJitteredProjectionMatrix(): UnityEngine.Matrix4x4;
            public set nonJitteredProjectionMatrix(value: UnityEngine.Matrix4x4);
            /** Should the jittered matrix be used for transparency rendering? */
            public get useJitteredProjectionMatrixForTransparentRendering(): boolean;
            public set useJitteredProjectionMatrixForTransparentRendering(value: boolean);
            /** Get the view projection matrix used on the last frame. */
            public get previousViewProjectionMatrix(): UnityEngine.Matrix4x4;
            
            /** The first enabled Camera component that is tagged "MainCamera" (Read Only). */
            public static get main(): UnityEngine.Camera;
            
            /** The camera we are currently rendering with, for low-level render control only (Read Only). */
            public static get current(): UnityEngine.Camera;
            
            /** If not null, the camera will only render the contents of the specified Scene. */
            public get scene(): UnityEngine.SceneManagement.Scene;
            public set scene(value: UnityEngine.SceneManagement.Scene);
            /** Stereoscopic rendering. */
            public get stereoEnabled(): boolean;
            
            /** The distance between the virtual eyes. Use this to query or set the current eye separation. Note that most VR devices provide this value, in which case setting the value will have no effect. */
            public get stereoSeparation(): number;
            public set stereoSeparation(value: number);
            /** Distance to a point where virtual eyes converge. */
            public get stereoConvergence(): number;
            public set stereoConvergence(value: number);
            /** Determines whether the stereo view matrices are suitable to allow for a single pass cull. */
            public get areVRStereoViewMatricesWithinSingleCullTolerance(): boolean;
            
            /** Defines which eye of a VR display the Camera renders into. */
            public get stereoTargetEye(): UnityEngine.StereoTargetEyeMask;
            public set stereoTargetEye(value: UnityEngine.StereoTargetEyeMask);
            /** Returns the eye that is currently rendering.
            If called when stereo is not enabled it will return Camera.MonoOrStereoscopicEye.Mono.
            If called during a camera rendering callback such as OnRenderImage it will return the currently rendering eye.
            If called outside of a rendering callback and stereo is enabled, it will return the default eye which is Camera.MonoOrStereoscopicEye.Left. */
            public get stereoActiveEye(): UnityEngine.Camera.MonoOrStereoscopicEye;
            
            /** The number of cameras in the current Scene. */
            public static get allCamerasCount(): number;
            
            /** Returns all enabled cameras in the Scene. */
            public static get allCameras(): System.Array$1<UnityEngine.Camera>;
            
            
            public get sceneViewFilterMode(): UnityEngine.Camera.SceneViewFilterMode;
            
            /** Number of command buffers set up on this camera (Read Only). */
            public get commandBufferCount(): number;
            
            
            public Reset():void;
            
            public ResetTransparencySortSettings():void;
            
            public ResetAspect():void;
            
            public ResetCullingMatrix():void;
            /** Make the camera render with shader replacement. */
            public SetReplacementShader($shader: UnityEngine.Shader, $replacementTag: string):void;
            
            public ResetReplacementShader():void;
            
            public GetGateFittedFieldOfView():number;
            
            public GetGateFittedLensShift():UnityEngine.Vector2;
            /** Sets the Camera to render to the chosen buffers of one or more RenderTextures. * @param colorBuffer The RenderBuffer(s) to which color information will be rendered.
             * @param depthBuffer The RenderBuffer to which depth information will be rendered.
             */
            public SetTargetBuffers($colorBuffer: UnityEngine.RenderBuffer, $depthBuffer: UnityEngine.RenderBuffer):void;
            /** Sets the Camera to render to the chosen buffers of one or more RenderTextures. * @param colorBuffer The RenderBuffer(s) to which color information will be rendered.
             * @param depthBuffer The RenderBuffer to which depth information will be rendered.
             */
            public SetTargetBuffers($colorBuffer: System.Array$1<UnityEngine.RenderBuffer>, $depthBuffer: UnityEngine.RenderBuffer):void;
            
            public ResetWorldToCameraMatrix():void;
            
            public ResetProjectionMatrix():void;
            /** Calculates and returns oblique near-plane projection matrix.
             * @param clipPlane Vector4 that describes a clip plane.
             * @returns Oblique near-plane projection matrix. 
             */
            public CalculateObliqueMatrix($clipPlane: UnityEngine.Vector4):UnityEngine.Matrix4x4;
            
            public WorldToScreenPoint($position: UnityEngine.Vector3, $eye: UnityEngine.Camera.MonoOrStereoscopicEye):UnityEngine.Vector3;
            
            public WorldToViewportPoint($position: UnityEngine.Vector3, $eye: UnityEngine.Camera.MonoOrStereoscopicEye):UnityEngine.Vector3;
            
            public ViewportToWorldPoint($position: UnityEngine.Vector3, $eye: UnityEngine.Camera.MonoOrStereoscopicEye):UnityEngine.Vector3;
            
            public ScreenToWorldPoint($position: UnityEngine.Vector3, $eye: UnityEngine.Camera.MonoOrStereoscopicEye):UnityEngine.Vector3;
            /** Transforms position from world space into screen space. * @param eye Optional argument that can be used to specify which eye transform to use. Default is Mono.
             */
            public WorldToScreenPoint($position: UnityEngine.Vector3):UnityEngine.Vector3;
            /** Transforms position from world space into viewport space. * @param eye Optional argument that can be used to specify which eye transform to use. Default is Mono.
             */
            public WorldToViewportPoint($position: UnityEngine.Vector3):UnityEngine.Vector3;
            /** Transforms position from viewport space into world space.
             * @param position The 3d vector in Viewport space.
             * @returns The 3d vector in World space. 
             */
            public ViewportToWorldPoint($position: UnityEngine.Vector3):UnityEngine.Vector3;
            /** Transforms a point from screen space into world space, where world space is defined as the coordinate system at the very top of your game's hierarchy.
             * @param position A screen space position (often mouse x, y), plus a z position for depth (for example, a camera clipping plane).
             * @param eye By default, Camera.MonoOrStereoscopicEye.Mono. Can be set to Camera.MonoOrStereoscopicEye.Left or Camera.MonoOrStereoscopicEye.Right for use in stereoscopic rendering (e.g., for VR).
             * @returns The worldspace point created by converting the screen space point at the provided distance z from the camera plane. 
             */
            public ScreenToWorldPoint($position: UnityEngine.Vector3):UnityEngine.Vector3;
            /** Transforms position from screen space into viewport space. */
            public ScreenToViewportPoint($position: UnityEngine.Vector3):UnityEngine.Vector3;
            /** Transforms position from viewport space into screen space. */
            public ViewportToScreenPoint($position: UnityEngine.Vector3):UnityEngine.Vector3;
            
            public ViewportPointToRay($pos: UnityEngine.Vector3, $eye: UnityEngine.Camera.MonoOrStereoscopicEye):UnityEngine.Ray;
            /** Returns a ray going from camera through a viewport point. * @param eye Optional argument that can be used to specify which eye transform to use. Default is Mono.
             */
            public ViewportPointToRay($pos: UnityEngine.Vector3):UnityEngine.Ray;
            
            public ScreenPointToRay($pos: UnityEngine.Vector3, $eye: UnityEngine.Camera.MonoOrStereoscopicEye):UnityEngine.Ray;
            /** Returns a ray going from camera through a screen point. * @param eye Optional argument that can be used to specify which eye transform to use. Default is Mono.
             */
            public ScreenPointToRay($pos: UnityEngine.Vector3):UnityEngine.Ray;
            
            public CalculateFrustumCorners($viewport: UnityEngine.Rect, $z: number, $eye: UnityEngine.Camera.MonoOrStereoscopicEye, $outCorners: System.Array$1<UnityEngine.Vector3>):void;
            
            public static CalculateProjectionMatrixFromPhysicalProperties($output: $Ref<UnityEngine.Matrix4x4>, $focalLength: number, $sensorSize: UnityEngine.Vector2, $lensShift: UnityEngine.Vector2, $nearClip: number, $farClip: number, $gateFitParameters?: UnityEngine.Camera.GateFitParameters):void;
            /** Converts focal length to field of view.
             * @param focalLength Focal length in millimeters.
             * @param sensorSize Sensor size in millimeters. Use the sensor height to get the vertical field of view. Use the sensor width to get the horizontal field of view.
             * @returns field of view in degrees. 
             */
            public static FocalLengthToFieldOfView($focalLength: number, $sensorSize: number):number;
            /** Converts field of view to focal length. Use either sensor height and vertical field of view or sensor width and horizontal field of view.
             * @param fieldOfView field of view in degrees.
             * @param sensorSize Sensor size in millimeters.
             * @returns Focal length in millimeters. 
             */
            public static FieldOfViewToFocalLength($fieldOfView: number, $sensorSize: number):number;
            /** Converts the horizontal field of view (FOV) to the vertical FOV, based on the value of the aspect ratio parameter. * @param horizontalFOV The horizontal FOV value in degrees.
             * @param aspectRatio The aspect ratio value used for the conversion
             */
            public static HorizontalToVerticalFieldOfView($horizontalFieldOfView: number, $aspectRatio: number):number;
            /** Converts the vertical field of view (FOV) to the horizontal FOV, based on the value of the aspect ratio parameter. * @param verticalFieldOfView The vertical FOV value in degrees.
             * @param aspectRatio The aspect ratio value used for the conversion
             */
            public static VerticalToHorizontalFieldOfView($verticalFieldOfView: number, $aspectRatio: number):number;
            
            public GetStereoNonJitteredProjectionMatrix($eye: UnityEngine.Camera.StereoscopicEye):UnityEngine.Matrix4x4;
            
            public GetStereoViewMatrix($eye: UnityEngine.Camera.StereoscopicEye):UnityEngine.Matrix4x4;
            
            public CopyStereoDeviceProjectionMatrixToNonJittered($eye: UnityEngine.Camera.StereoscopicEye):void;
            
            public GetStereoProjectionMatrix($eye: UnityEngine.Camera.StereoscopicEye):UnityEngine.Matrix4x4;
            
            public SetStereoProjectionMatrix($eye: UnityEngine.Camera.StereoscopicEye, $matrix: UnityEngine.Matrix4x4):void;
            
            public ResetStereoProjectionMatrices():void;
            
            public SetStereoViewMatrix($eye: UnityEngine.Camera.StereoscopicEye, $matrix: UnityEngine.Matrix4x4):void;
            
            public ResetStereoViewMatrices():void;
            /** Fills an array of Camera with the current cameras in the Scene, without allocating a new array. * @param cameras An array to be filled up with cameras currently in the Scene.
             */
            public static GetAllCameras($cameras: System.Array$1<UnityEngine.Camera>):number;
            /** Render into a static cubemap from this camera.
             * @param cubemap The cube map to render to.
             * @param faceMask A bitmask which determines which of the six faces are rendered to.
             * @returns False if rendering fails, else true. 
             */
            public RenderToCubemap($cubemap: UnityEngine.Cubemap, $faceMask: number):boolean;
            
            public RenderToCubemap($cubemap: UnityEngine.Cubemap):boolean;
            /** Render into a cubemap from this camera.
             * @param faceMask A bitfield indicating which cubemap faces should be rendered into.
             * @param cubemap The texture to render to.
             * @returns False if rendering fails, else true. 
             */
            public RenderToCubemap($cubemap: UnityEngine.RenderTexture, $faceMask: number):boolean;
            
            public RenderToCubemap($cubemap: UnityEngine.RenderTexture):boolean;
            
            public RenderToCubemap($cubemap: UnityEngine.RenderTexture, $faceMask: number, $stereoEye: UnityEngine.Camera.MonoOrStereoscopicEye):boolean;
            
            public Render():void;
            /** Render the camera with shader replacement. */
            public RenderWithShader($shader: UnityEngine.Shader, $replacementTag: string):void;
            
            public RenderDontRestore():void;
            
            public SubmitRenderRequests($renderRequests: System.Collections.Generic.List$1<UnityEngine.Camera.RenderRequest>):void;
            
            public static SetupCurrent($cur: UnityEngine.Camera):void;
            /** Makes this camera's settings match other camera. * @param other Copy camera settings to the other camera.
             */
            public CopyFrom($other: UnityEngine.Camera):void;
            /** Remove command buffers from execution at a specified place. * @param evt When to execute the command buffer during rendering.
             */
            public RemoveCommandBuffers($evt: UnityEngine.Rendering.CameraEvent):void;
            
            public RemoveAllCommandBuffers():void;
            /** Add a command buffer to be executed at a specified place. * @param evt When to execute the command buffer during rendering.
             * @param buffer The buffer to execute.
             */
            public AddCommandBuffer($evt: UnityEngine.Rendering.CameraEvent, $buffer: UnityEngine.Rendering.CommandBuffer):void;
            /** Adds a command buffer to the GPU's async compute queues and executes that command buffer when graphics processing reaches a given point. * @param evt The point during the graphics processing at which this command buffer should commence on the GPU.
             * @param buffer The buffer to execute.
             * @param queueType The desired async compute queue type to execute the buffer on.
             */
            public AddCommandBufferAsync($evt: UnityEngine.Rendering.CameraEvent, $buffer: UnityEngine.Rendering.CommandBuffer, $queueType: UnityEngine.Rendering.ComputeQueueType):void;
            /** Remove command buffer from execution at a specified place. * @param evt When to execute the command buffer during rendering.
             * @param buffer The buffer to execute.
             */
            public RemoveCommandBuffer($evt: UnityEngine.Rendering.CameraEvent, $buffer: UnityEngine.Rendering.CommandBuffer):void;
            /** Get command buffers to be executed at a specified place.
             * @param evt When to execute the command buffer during rendering.
             * @returns Array of command buffers. 
             */
            public GetCommandBuffers($evt: UnityEngine.Rendering.CameraEvent):System.Array$1<UnityEngine.Rendering.CommandBuffer>;
            /** Get culling parameters for a camera.
             * @param cullingParameters Resultant culling parameters.
             * @param stereoAware Generate single-pass stereo aware culling parameters.
             * @returns Flag indicating whether culling parameters are valid. 
             */
            public TryGetCullingParameters($cullingParameters: $Ref<UnityEngine.Rendering.ScriptableCullingParameters>):boolean;
            /** Get culling parameters for a camera.
             * @param cullingParameters Resultant culling parameters.
             * @param stereoAware Generate single-pass stereo aware culling parameters.
             * @returns Flag indicating whether culling parameters are valid. 
             */
            public TryGetCullingParameters($stereoAware: boolean, $cullingParameters: $Ref<UnityEngine.Rendering.ScriptableCullingParameters>):boolean;
            
            public constructor();
            
        }
        
        /** Behaviours are Components that can be enabled or disabled. */
        class Behaviour extends UnityEngine.Component{ 
            
        }
        
        /** Rendering path of a Camera. */
        enum RenderingPath{ UsePlayerSettings = -1, VertexLit = 0, Forward = 1, DeferredLighting = 2, DeferredShading = 3 }
        
        /** Transparent object sorting mode of a Camera. */
        enum TransparencySortMode{ Default = 0, Perspective = 1, Orthographic = 2, CustomAxis = 3 }
        
        /** Describes different types of camera. */
        enum CameraType{ Game = 1, SceneView = 2, Preview = 4, VR = 8, Reflection = 16 }
        
        /** Values for Camera.clearFlags, determining what to clear when rendering a Camera. */
        enum CameraClearFlags{ Skybox = 1, Color = 2, SolidColor = 2, Depth = 3, Nothing = 4 }
        
        /** Depth texture generation mode for Camera. */
        enum DepthTextureMode{ None = 0, Depth = 1, DepthNormals = 2, MotionVectors = 4 }
        
        /** Shader scripts used for all rendering. */
        class Shader extends UnityEngine.Object{ 
            
        }
        
        /** Representation of 2D vectors and points. */
        class Vector2 extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Vector2>{ 
            
        }
        
        /** A 2D Rectangle defined by X and Y position, width and height. */
        class Rect extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Rect>{ 
            
        }
        
        /** Render textures are textures that can be rendered to. */
        class RenderTexture extends UnityEngine.Texture{ 
            
        }
        
        /** Base class for Texture handling. */
        class Texture extends UnityEngine.Object{ 
            
        }
        
        /** Color or depth buffer part of a RenderTexture. */
        class RenderBuffer extends System.ValueType{ 
            
        }
        
        /** Representation of four-dimensional vectors. */
        class Vector4 extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Vector4>{ 
            
        }
        
        /** Representation of rays. */
        class Ray extends System.ValueType implements System.IFormattable{ 
            
        }
        
        /** Enum values for the Camera's targetEye property. */
        enum StereoTargetEyeMask{ None = 0, Left = 1, Right = 2, Both = 3 }
        
        /** Class for handling cube maps, Use this to create or modify existing. */
        class Cubemap extends UnityEngine.Texture{ 
            
        }
        
        /** Script interface for. */
        class Light extends UnityEngine.Behaviour{ 
            /** The type of the light. */
            public get type(): UnityEngine.LightType;
            public set type(value: UnityEngine.LightType);
            /** This property describes the shape of the spot light. Only Scriptable Render Pipelines use this property; the built-in renderer does not support it. */
            public get shape(): UnityEngine.LightShape;
            public set shape(value: UnityEngine.LightShape);
            /** The angle of the light's spotlight cone in degrees. */
            public get spotAngle(): number;
            public set spotAngle(value: number);
            /** The angle of the light's spotlight inner cone in degrees. */
            public get innerSpotAngle(): number;
            public set innerSpotAngle(value: number);
            /** The color of the light. */
            public get color(): UnityEngine.Color;
            public set color(value: UnityEngine.Color);
            /** 
                      The color temperature of the light.
                      Correlated Color Temperature (abbreviated as CCT) is multiplied with the color filter when calculating the final color of a light source. The color temperature of the electromagnetic radiation emitted from an ideal black body is defined as its surface temperature in Kelvin. White is 6500K according to the D65 standard. A candle light is 1800K and a soft warm light bulb is 2700K.
                      If you want to use colorTemperature, GraphicsSettings.lightsUseLinearIntensity and Light.useColorTemperature has to be enabled.
                      See Also: GraphicsSettings.lightsUseLinearIntensity, GraphicsSettings.useColorTemperature.
                     */
            public get colorTemperature(): number;
            public set colorTemperature(value: number);
            /** Set to true to use the color temperature. */
            public get useColorTemperature(): boolean;
            public set useColorTemperature(value: boolean);
            /** The Intensity of a light is multiplied with the Light color. */
            public get intensity(): number;
            public set intensity(value: number);
            /** The multiplier that defines the strength of the bounce lighting. */
            public get bounceIntensity(): number;
            public set bounceIntensity(value: number);
            /** Set to true to override light bounding sphere for culling. */
            public get useBoundingSphereOverride(): boolean;
            public set useBoundingSphereOverride(value: boolean);
            /** Bounding sphere used to override the regular light bounding sphere during culling. */
            public get boundingSphereOverride(): UnityEngine.Vector4;
            public set boundingSphereOverride(value: UnityEngine.Vector4);
            /** Whether to cull shadows for this Light when the Light is outside of the view frustum. */
            public get useViewFrustumForShadowCasterCull(): boolean;
            public set useViewFrustumForShadowCasterCull(value: boolean);
            /** The custom resolution of the shadow map. */
            public get shadowCustomResolution(): number;
            public set shadowCustomResolution(value: number);
            /** Shadow mapping constant bias. */
            public get shadowBias(): number;
            public set shadowBias(value: number);
            /** Shadow mapping normal-based bias. */
            public get shadowNormalBias(): number;
            public set shadowNormalBias(value: number);
            /** Near plane value to use for shadow frustums. */
            public get shadowNearPlane(): number;
            public set shadowNearPlane(value: number);
            /** Set to true to enable custom matrix for culling during shadows. */
            public get useShadowMatrixOverride(): boolean;
            public set useShadowMatrixOverride(value: boolean);
            /** Projection matrix used to override the regular light matrix during shadow culling. */
            public get shadowMatrixOverride(): UnityEngine.Matrix4x4;
            public set shadowMatrixOverride(value: UnityEngine.Matrix4x4);
            /** The range of the light. */
            public get range(): number;
            public set range(value: number);
            /** The to use for this light. */
            public get flare(): UnityEngine.Flare;
            public set flare(value: UnityEngine.Flare);
            /** This property describes the output of the last Global Illumination bake. */
            public get bakingOutput(): UnityEngine.LightBakingOutput;
            public set bakingOutput(value: UnityEngine.LightBakingOutput);
            /** This is used to light certain objects in the Scene selectively. */
            public get cullingMask(): number;
            public set cullingMask(value: number);
            /** Determines which rendering LayerMask this Light affects. */
            public get renderingLayerMask(): number;
            public set renderingLayerMask(value: number);
            /** Allows you to override the global Shadowmask Mode per light. Only use this with render pipelines that can handle per light Shadowmask modes. Incompatible with the legacy renderers. */
            public get lightShadowCasterMode(): UnityEngine.LightShadowCasterMode;
            public set lightShadowCasterMode(value: UnityEngine.LightShadowCasterMode);
            /** Controls the amount of artificial softening applied to the edges of shadows cast by the Point or Spot light. */
            public get shadowRadius(): number;
            public set shadowRadius(value: number);
            /** Controls the amount of artificial softening applied to the edges of shadows cast by directional lights. */
            public get shadowAngle(): number;
            public set shadowAngle(value: number);
            /** How this light casts shadows */
            public get shadows(): UnityEngine.LightShadows;
            public set shadows(value: UnityEngine.LightShadows);
            /** Strength of light's shadows. */
            public get shadowStrength(): number;
            public set shadowStrength(value: number);
            /** The resolution of the shadow map. */
            public get shadowResolution(): UnityEngine.Rendering.LightShadowResolution;
            public set shadowResolution(value: UnityEngine.Rendering.LightShadowResolution);
            /** Per-light, per-layer shadow culling distances. Directional lights only.  */
            public get layerShadowCullDistances(): System.Array$1<number>;
            public set layerShadowCullDistances(value: System.Array$1<number>);
            /** The size of a directional light's cookie. */
            public get cookieSize(): number;
            public set cookieSize(value: number);
            /** The cookie texture projected by the light. */
            public get cookie(): UnityEngine.Texture;
            public set cookie(value: UnityEngine.Texture);
            /** How to render the light. */
            public get renderMode(): UnityEngine.LightRenderMode;
            public set renderMode(value: UnityEngine.LightRenderMode);
            /** The size of the area light (Editor only). */
            public get areaSize(): UnityEngine.Vector2;
            public set areaSize(value: UnityEngine.Vector2);
            /** This property describes what part of a light's contribution can be baked (Editor only). */
            public get lightmapBakeType(): UnityEngine.LightmapBakeType;
            public set lightmapBakeType(value: UnityEngine.LightmapBakeType);
            /** Number of command buffers set up on this light (Read Only). */
            public get commandBufferCount(): number;
            
            
            public Reset():void;
            
            public SetLightDirty():void;
            /** Add a command buffer to be executed at a specified place. * @param evt When to execute the command buffer during rendering.
             * @param buffer The buffer to execute.
             * @param shadowPassMask A mask specifying which shadow passes to execute the buffer for.
             */
            public AddCommandBuffer($evt: UnityEngine.Rendering.LightEvent, $buffer: UnityEngine.Rendering.CommandBuffer):void;
            /** Add a command buffer to be executed at a specified place. * @param evt When to execute the command buffer during rendering.
             * @param buffer The buffer to execute.
             * @param shadowPassMask A mask specifying which shadow passes to execute the buffer for.
             */
            public AddCommandBuffer($evt: UnityEngine.Rendering.LightEvent, $buffer: UnityEngine.Rendering.CommandBuffer, $shadowPassMask: UnityEngine.Rendering.ShadowMapPass):void;
            /** Adds a command buffer to the GPU's async compute queues and executes that command buffer when graphics processing reaches a given point. * @param evt The point during the graphics processing at which this command buffer should commence on the GPU.
             * @param buffer The buffer to execute.
             * @param queueType The desired async compute queue type to execute the buffer on.
             * @param shadowPassMask A mask specifying which shadow passes to execute the buffer for.
             */
            public AddCommandBufferAsync($evt: UnityEngine.Rendering.LightEvent, $buffer: UnityEngine.Rendering.CommandBuffer, $queueType: UnityEngine.Rendering.ComputeQueueType):void;
            /** Adds a command buffer to the GPU's async compute queues and executes that command buffer when graphics processing reaches a given point. * @param evt The point during the graphics processing at which this command buffer should commence on the GPU.
             * @param buffer The buffer to execute.
             * @param queueType The desired async compute queue type to execute the buffer on.
             * @param shadowPassMask A mask specifying which shadow passes to execute the buffer for.
             */
            public AddCommandBufferAsync($evt: UnityEngine.Rendering.LightEvent, $buffer: UnityEngine.Rendering.CommandBuffer, $shadowPassMask: UnityEngine.Rendering.ShadowMapPass, $queueType: UnityEngine.Rendering.ComputeQueueType):void;
            /** Remove command buffer from execution at a specified place. * @param evt When to execute the command buffer during rendering.
             * @param buffer The buffer to execute.
             */
            public RemoveCommandBuffer($evt: UnityEngine.Rendering.LightEvent, $buffer: UnityEngine.Rendering.CommandBuffer):void;
            /** Remove command buffers from execution at a specified place. * @param evt When to execute the command buffer during rendering.
             */
            public RemoveCommandBuffers($evt: UnityEngine.Rendering.LightEvent):void;
            
            public RemoveAllCommandBuffers():void;
            /** Get command buffers to be executed at a specified place.
             * @param evt When to execute the command buffer during rendering.
             * @returns Array of command buffers. 
             */
            public GetCommandBuffers($evt: UnityEngine.Rendering.LightEvent):System.Array$1<UnityEngine.Rendering.CommandBuffer>;
            
            public static GetLights($type: UnityEngine.LightType, $layer: number):System.Array$1<UnityEngine.Light>;
            
            public constructor();
            
        }
        
        /** The type of a Light. */
        enum LightType{ Spot = 0, Directional = 1, Point = 2, Area = 3, Rectangle = 3, Disc = 4 }
        
        /** Describes the shape of a spot light. */
        enum LightShape{ Cone = 0, Pyramid = 1, Box = 2 }
        
        /** A flare asset. Read more about flares in the. */
        class Flare extends UnityEngine.Object{ 
            
        }
        
        /** Struct describing the result of a Global Illumination bake for a given light. */
        class LightBakingOutput extends System.ValueType{ 
            
        }
        
        /** Allows mixed lights to control shadow caster culling when Shadowmasks are present. */
        enum LightShadowCasterMode{ Default = 0, NonLightmappedOnly = 1, Everything = 2 }
        
        /** Shadow casting options for a Light. */
        enum LightShadows{ None = 0, Hard = 1, Soft = 2 }
        
        /** How the Light is rendered. */
        enum LightRenderMode{ Auto = 0, ForcePixel = 1, ForceVertex = 2 }
        
        /** Enum describing what part of a light contribution can be baked. */
        enum LightmapBakeType{ Realtime = 4, Baked = 2, Mixed = 1 }
        
        
        enum LightmappingMode{ Realtime = 4, Baked = 2, Mixed = 1 }
        
        /** Script interface for ParticleSystem. Unity's powerful and versatile particle system implementation. */
        class ParticleSystem extends UnityEngine.Component{ 
            /** Determines whether the Particle System is playing. */
            public get isPlaying(): boolean;
            
            /** Determines whether the Particle System is emitting particles. A Particle System may stop emitting when its emission module has finished, it has been paused or if the system has been stopped using ParticleSystem.Stop|Stop with the ParticleSystemStopBehavior.StopEmitting|StopEmitting flag. Resume emitting by calling ParticleSystem.Play|Play. */
            public get isEmitting(): boolean;
            
            /** Determines whether the Particle System is in the stopped state. */
            public get isStopped(): boolean;
            
            /** Determines whether the Particle System is paused. */
            public get isPaused(): boolean;
            
            /** The current number of particles (Read Only). */
            public get particleCount(): number;
            
            /** Playback position in seconds. */
            public get time(): number;
            public set time(value: number);
            /** Override the random seed used for the Particle System emission. */
            public get randomSeed(): number;
            public set randomSeed(value: number);
            /** Controls whether the Particle System uses an automatically-generated random number to seed the random number generator. */
            public get useAutoRandomSeed(): boolean;
            public set useAutoRandomSeed(value: boolean);
            /** Does this system support Procedural Simulation? */
            public get proceduralSimulationSupported(): boolean;
            
            /** Access the main Particle System settings. */
            public get main(): UnityEngine.ParticleSystem.MainModule;
            
            /** Script interface for the EmissionModule of a Particle System. */
            public get emission(): UnityEngine.ParticleSystem.EmissionModule;
            
            /** Script interface for the ShapeModule of a Particle System.  */
            public get shape(): UnityEngine.ParticleSystem.ShapeModule;
            
            /** Script interface for the VelocityOverLifetimeModule of a Particle System. */
            public get velocityOverLifetime(): UnityEngine.ParticleSystem.VelocityOverLifetimeModule;
            
            /** Script interface for the LimitVelocityOverLifetimeModule of a Particle System. . */
            public get limitVelocityOverLifetime(): UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule;
            
            /** Script interface for the InheritVelocityModule of a Particle System. */
            public get inheritVelocity(): UnityEngine.ParticleSystem.InheritVelocityModule;
            
            /** Script interface for the Particle System Lifetime By Emitter Speed module. */
            public get lifetimeByEmitterSpeed(): UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule;
            
            /** Script interface for the ForceOverLifetimeModule of a Particle System. */
            public get forceOverLifetime(): UnityEngine.ParticleSystem.ForceOverLifetimeModule;
            
            /** Script interface for the ColorOverLifetimeModule of a Particle System. */
            public get colorOverLifetime(): UnityEngine.ParticleSystem.ColorOverLifetimeModule;
            
            /** Script interface for the ColorByLifetimeModule of a Particle System. */
            public get colorBySpeed(): UnityEngine.ParticleSystem.ColorBySpeedModule;
            
            /** Script interface for the SizeOverLifetimeModule of a Particle System.  */
            public get sizeOverLifetime(): UnityEngine.ParticleSystem.SizeOverLifetimeModule;
            
            /** Script interface for the SizeBySpeedModule of a Particle System. */
            public get sizeBySpeed(): UnityEngine.ParticleSystem.SizeBySpeedModule;
            
            /** Script interface for the RotationOverLifetimeModule of a Particle System. */
            public get rotationOverLifetime(): UnityEngine.ParticleSystem.RotationOverLifetimeModule;
            
            /** Script interface for the RotationBySpeedModule of a Particle System. */
            public get rotationBySpeed(): UnityEngine.ParticleSystem.RotationBySpeedModule;
            
            /** Script interface for the ExternalForcesModule of a Particle System. */
            public get externalForces(): UnityEngine.ParticleSystem.ExternalForcesModule;
            
            /** Script interface for the NoiseModule of a Particle System. */
            public get noise(): UnityEngine.ParticleSystem.NoiseModule;
            
            /** Script interface for the CollisionModule of a Particle System. */
            public get collision(): UnityEngine.ParticleSystem.CollisionModule;
            
            /** Script interface for the TriggerModule of a Particle System. */
            public get trigger(): UnityEngine.ParticleSystem.TriggerModule;
            
            /** Script interface for the SubEmittersModule of a Particle System. */
            public get subEmitters(): UnityEngine.ParticleSystem.SubEmittersModule;
            
            /** Script interface for the TextureSheetAnimationModule of a Particle System. */
            public get textureSheetAnimation(): UnityEngine.ParticleSystem.TextureSheetAnimationModule;
            
            /** Script interface for the LightsModule of a Particle System. */
            public get lights(): UnityEngine.ParticleSystem.LightsModule;
            
            /** Script interface for the TrailsModule of a Particle System. */
            public get trails(): UnityEngine.ParticleSystem.TrailModule;
            
            /** Script interface for the CustomDataModule of a Particle System. */
            public get customData(): UnityEngine.ParticleSystem.CustomDataModule;
            
            
            public SetParticles($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>, $size: number, $offset: number):void;
            
            public SetParticles($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>, $size: number):void;
            
            public SetParticles($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>):void;
            
            public SetParticles($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>, $size: number, $offset: number):void;
            
            public SetParticles($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>, $size: number):void;
            
            public SetParticles($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>):void;
            
            public GetParticles($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>, $size: number, $offset: number):number;
            
            public GetParticles($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>, $size: number):number;
            
            public GetParticles($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>):number;
            
            public GetParticles($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>, $size: number, $offset: number):number;
            
            public GetParticles($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>, $size: number):number;
            
            public GetParticles($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>):number;
            
            public SetCustomParticleData($customData: System.Collections.Generic.List$1<UnityEngine.Vector4>, $streamIndex: UnityEngine.ParticleSystemCustomData):void;
            
            public GetCustomParticleData($customData: System.Collections.Generic.List$1<UnityEngine.Vector4>, $streamIndex: UnityEngine.ParticleSystemCustomData):number;
            
            public GetPlaybackState():UnityEngine.ParticleSystem.PlaybackState;
            
            public SetPlaybackState($playbackState: UnityEngine.ParticleSystem.PlaybackState):void;
            
            public GetTrails():UnityEngine.ParticleSystem.Trails;
            
            public SetTrails($trailData: UnityEngine.ParticleSystem.Trails):void;
            /** Fast-forwards the Particle System by simulating particles over the given period of time, then pauses it. * @param t Time period in seconds to advance the ParticleSystem simulation by. If restart is true, the ParticleSystem will be reset to 0 time, and then advanced by this value. If restart is false, the ParticleSystem simulation will be advanced in time from its current state by this value.
             * @param withChildren Fast-forward all child Particle Systems as well.
             * @param restart Restart and start from the beginning.
             * @param fixedTimeStep Only update the system at fixed intervals, based on the value in "Fixed Time" in the Time options.
             */
            public Simulate($t: number, $withChildren: boolean, $restart: boolean, $fixedTimeStep: boolean):void;
            /** Fast-forwards the Particle System by simulating particles over the given period of time, then pauses it. * @param t Time period in seconds to advance the ParticleSystem simulation by. If restart is true, the ParticleSystem will be reset to 0 time, and then advanced by this value. If restart is false, the ParticleSystem simulation will be advanced in time from its current state by this value.
             * @param withChildren Fast-forward all child Particle Systems as well.
             * @param restart Restart and start from the beginning.
             * @param fixedTimeStep Only update the system at fixed intervals, based on the value in "Fixed Time" in the Time options.
             */
            public Simulate($t: number, $withChildren: boolean, $restart: boolean):void;
            /** Fast-forwards the Particle System by simulating particles over the given period of time, then pauses it. * @param t Time period in seconds to advance the ParticleSystem simulation by. If restart is true, the ParticleSystem will be reset to 0 time, and then advanced by this value. If restart is false, the ParticleSystem simulation will be advanced in time from its current state by this value.
             * @param withChildren Fast-forward all child Particle Systems as well.
             * @param restart Restart and start from the beginning.
             * @param fixedTimeStep Only update the system at fixed intervals, based on the value in "Fixed Time" in the Time options.
             */
            public Simulate($t: number, $withChildren: boolean):void;
            /** Fast-forwards the Particle System by simulating particles over the given period of time, then pauses it. * @param t Time period in seconds to advance the ParticleSystem simulation by. If restart is true, the ParticleSystem will be reset to 0 time, and then advanced by this value. If restart is false, the ParticleSystem simulation will be advanced in time from its current state by this value.
             * @param withChildren Fast-forward all child Particle Systems as well.
             * @param restart Restart and start from the beginning.
             * @param fixedTimeStep Only update the system at fixed intervals, based on the value in "Fixed Time" in the Time options.
             */
            public Simulate($t: number):void;
            /** Starts the Particle System. * @param withChildren Play all child Particle Systems as well.
             */
            public Play($withChildren: boolean):void;
            
            public Play():void;
            /** Pauses the system so no new particles are emitted and the existing particles are not updated. * @param withChildren Pause all child Particle Systems as well.
             */
            public Pause($withChildren: boolean):void;
            
            public Pause():void;
            /** Stops playing the Particle System using the supplied stop behaviour. * @param withChildren Stop all child Particle Systems as well.
             * @param stopBehavior Stop emitting or stop emitting and clear the system.
             */
            public Stop($withChildren: boolean, $stopBehavior: UnityEngine.ParticleSystemStopBehavior):void;
            /** Stops playing the Particle System using the supplied stop behaviour. * @param withChildren Stop all child Particle Systems as well.
             * @param stopBehavior Stop emitting or stop emitting and clear the system.
             */
            public Stop($withChildren: boolean):void;
            
            public Stop():void;
            /** Remove all particles in the Particle System. * @param withChildren Clear all child Particle Systems as well.
             */
            public Clear($withChildren: boolean):void;
            
            public Clear():void;
            /** Does the Particle System contain any live particles, or will it produce more?
             * @param withChildren Check all child Particle Systems as well.
             * @returns True if the Particle System contains live particles or is still creating new particles. False if the Particle System has stopped emitting particles and all particles are dead. 
             */
            public IsAlive($withChildren: boolean):boolean;
            
            public IsAlive():boolean;
            /** Emit count particles immediately. * @param count Number of particles to emit.
             */
            public Emit($count: number):void;
            
            public Emit($emitParams: UnityEngine.ParticleSystem.EmitParams, $count: number):void;
            /** Triggers the specified sub emitter on all particles of the Particle System. * @param subEmitterIndex Index of the sub emitter to trigger.
             */
            public TriggerSubEmitter($subEmitterIndex: number):void;
            
            public TriggerSubEmitter($subEmitterIndex: number, $particle: $Ref<UnityEngine.ParticleSystem.Particle>):void;
            
            public TriggerSubEmitter($subEmitterIndex: number, $particles: System.Collections.Generic.List$1<UnityEngine.ParticleSystem.Particle>):void;
            
            public static ResetPreMappedBufferMemory():void;
            /** Limits the amount of graphics memory Unity reserves for efficient rendering of Particle Systems. * @param vertexBuffersCount The maximum number of cached vertex buffers.
             * @param indexBuffersCount The maximum number of cached index buffers.
             */
            public static SetMaximumPreMappedBufferCounts($vertexBuffersCount: number, $indexBuffersCount: number):void;
            
            public AllocateAxisOfRotationAttribute():void;
            
            public AllocateMeshIndexAttribute():void;
            /** Ensures that the ParticleSystemJobs.ParticleSystemJobData.customData1|customData1 and ParticleSystemJobs.ParticleSystemJobData.customData1|customData2 particle attribute arrays are allocated. * @param stream The custom data stream to allocate.
             */
            public AllocateCustomDataAttribute($stream: UnityEngine.ParticleSystemCustomData):void;
            
            public constructor();
            
        }
        
        /** Representation of RGBA colors in 32 bit format. */
        class Color32 extends System.ValueType implements System.IFormattable{ 
            
        }
        
        /** The space to simulate particles in. */
        enum ParticleSystemSimulationSpace{ Local = 0, World = 1, Custom = 2 }
        
        /** Control how particle systems apply transform scale. */
        enum ParticleSystemScalingMode{ Hierarchy = 0, Local = 1, Shape = 2 }
        
        /** Which stream of custom particle data to set. */
        enum ParticleSystemCustomData{ Custom1 = 0, Custom2 = 1 }
        
        /** The behavior to apply when calling ParticleSystem.Stop|Stop. */
        enum ParticleSystemStopBehavior{ StopEmittingAndClear = 0, StopEmitting = 1 }
        
        /** Position, size, anchor and pivot information for a rectangle. */
        class RectTransform extends UnityEngine.Transform implements System.Collections.IEnumerable{ 
            /** The calculated rectangle in the local space of the Transform. */
            public get rect(): UnityEngine.Rect;
            
            /** The normalized position in the parent RectTransform that the lower left corner is anchored to. */
            public get anchorMin(): UnityEngine.Vector2;
            public set anchorMin(value: UnityEngine.Vector2);
            /** The normalized position in the parent RectTransform that the upper right corner is anchored to. */
            public get anchorMax(): UnityEngine.Vector2;
            public set anchorMax(value: UnityEngine.Vector2);
            /** The position of the pivot of this RectTransform relative to the anchor reference point. */
            public get anchoredPosition(): UnityEngine.Vector2;
            public set anchoredPosition(value: UnityEngine.Vector2);
            /** The size of this RectTransform relative to the distances between the anchors. */
            public get sizeDelta(): UnityEngine.Vector2;
            public set sizeDelta(value: UnityEngine.Vector2);
            /** The normalized position in this RectTransform that it rotates around. */
            public get pivot(): UnityEngine.Vector2;
            public set pivot(value: UnityEngine.Vector2);
            /** The 3D position of the pivot of this RectTransform relative to the anchor reference point. */
            public get anchoredPosition3D(): UnityEngine.Vector3;
            public set anchoredPosition3D(value: UnityEngine.Vector3);
            /** The offset of the lower left corner of the rectangle relative to the lower left anchor. */
            public get offsetMin(): UnityEngine.Vector2;
            public set offsetMin(value: UnityEngine.Vector2);
            /** The offset of the upper right corner of the rectangle relative to the upper right anchor. */
            public get offsetMax(): UnityEngine.Vector2;
            public set offsetMax(value: UnityEngine.Vector2);
            /** The object that is driving the values of this RectTransform. Value is null if not driven. */
            public get drivenByObject(): UnityEngine.Object;
            
            
            public static add_reapplyDrivenProperties($value: UnityEngine.RectTransform.ReapplyDrivenProperties):void;
            
            public static remove_reapplyDrivenProperties($value: UnityEngine.RectTransform.ReapplyDrivenProperties):void;
            
            public ForceUpdateRectTransforms():void;
            /** Get the corners of the calculated rectangle in the local space of its Transform. * @param fourCornersArray The array that corners are filled into.
             */
            public GetLocalCorners($fourCornersArray: System.Array$1<UnityEngine.Vector3>):void;
            /** Get the corners of the calculated rectangle in world space. * @param fourCornersArray The array that corners are filled into.
             */
            public GetWorldCorners($fourCornersArray: System.Array$1<UnityEngine.Vector3>):void;
            
            public SetInsetAndSizeFromParentEdge($edge: UnityEngine.RectTransform.Edge, $inset: number, $size: number):void;
            
            public SetSizeWithCurrentAnchors($axis: UnityEngine.RectTransform.Axis, $size: number):void;
            
            public constructor();
            
        }
        
        /** MonoBehaviour is the base class from which every Unity script derives. */
        class MonoBehaviour extends UnityEngine.Behaviour{ 
            
        }
        
        
        interface ICanvasRaycastFilter{ 
            
        }
        
        
        interface ISerializationCallbackReceiver{ 
            
        }
        
        /** Represents a Sprite object for use in 2D gameplay. */
        class Sprite extends UnityEngine.Object{ 
            
        }
        
        /** The material class. */
        class Material extends UnityEngine.Object{ 
            
        }
        
        /** A class you can derive from if you want to create objects that don't need to be attached to game objects. */
        class ScriptableObject extends UnityEngine.Object{ 
            
        }
        
        /** A class that allows you to create or modify meshes. */
        class Mesh extends UnityEngine.Object{ 
            
        }
        
        /** Represents an axis aligned bounding box. */
        class Bounds extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Bounds>{ 
            
        }
        
        /** Enumeration of the different types of supported touchscreen keyboards. */
        enum TouchScreenKeyboardType{ Default = 0, ASCIICapable = 1, NumbersAndPunctuation = 2, URL = 3, NumberPad = 4, PhonePad = 5, NamePhonePad = 6, EmailAddress = 7, NintendoNetworkAccount = 8, Social = 9, Search = 10, DecimalPad = 11, OneTimeCode = 12 }
        
        /** A UnityGUI event. */
        class Event extends System.Object{ 
            
        }
        
        /** Helper class to generate form data to post to web servers using the UnityWebRequest or WWW classes. */
        class WWWForm extends System.Object{ 
            
        }
        
        
    }
    namespace UnityEngine.SceneManagement {
        /** Run-time data structure for *.unity file. */
        class Scene extends System.ValueType{ 
            
        }
        
        
    }
    namespace UnityEngine.Camera {
        
        interface CameraCallback { (cam: UnityEngine.Camera) : void; } 
        var CameraCallback: {new (func: (cam: UnityEngine.Camera) => void): CameraCallback;}
        
        
        enum GateFitMode{ Vertical = 1, Horizontal = 2, Fill = 3, Overscan = 4, None = 0 }
        
        
        enum MonoOrStereoscopicEye{ Left = 0, Right = 1, Mono = 2 }
        
        
        class GateFitParameters extends System.ValueType{ 
            
        }
        
        
        enum StereoscopicEye{ Left = 0, Right = 1 }
        
        
        enum SceneViewFilterMode{ Off = 0, ShowFiltered = 1 }
        
        
        class RenderRequest extends System.ValueType{ 
            
        }
        
        
    }
    namespace UnityEngine.Rendering {
        /** Opaque object sorting mode of a Camera. */
        enum OpaqueSortMode{ Default = 0, FrontToBack = 1, NoDistanceSort = 2 }
        
        /** Defines a place in camera's rendering to attach Rendering.CommandBuffer objects to. */
        enum CameraEvent{ BeforeDepthTexture = 0, AfterDepthTexture = 1, BeforeDepthNormalsTexture = 2, AfterDepthNormalsTexture = 3, BeforeGBuffer = 4, AfterGBuffer = 5, BeforeLighting = 6, AfterLighting = 7, BeforeFinalPass = 8, AfterFinalPass = 9, BeforeForwardOpaque = 10, AfterForwardOpaque = 11, BeforeImageEffectsOpaque = 12, AfterImageEffectsOpaque = 13, BeforeSkybox = 14, AfterSkybox = 15, BeforeForwardAlpha = 16, AfterForwardAlpha = 17, BeforeImageEffects = 18, AfterImageEffects = 19, AfterEverything = 20, BeforeReflections = 21, AfterReflections = 22, BeforeHaloAndLensFlares = 23, AfterHaloAndLensFlares = 24 }
        
        /** List of graphics commands to execute. */
        class CommandBuffer extends System.Object implements System.IDisposable{ 
            
        }
        
        /** Describes the desired characteristics with respect to prioritisation and load balancing of the queue that a command buffer being submitted via Graphics.ExecuteCommandBufferAsync or [[ScriptableRenderContext.ExecuteCommandBufferAsync] should be sent to. */
        enum ComputeQueueType{ Default = 0, Background = 1, Urgent = 2 }
        
        /** Parameters that configure a culling operation in the Scriptable Render Pipeline. */
        class ScriptableCullingParameters extends System.ValueType implements System.IEquatable$1<UnityEngine.Rendering.ScriptableCullingParameters>{ 
            
        }
        
        /** Shadow resolution options for a Light. */
        enum LightShadowResolution{ FromQualitySettings = -1, Low = 0, Medium = 1, High = 2, VeryHigh = 3 }
        
        /** Defines a place in light's rendering to attach Rendering.CommandBuffer objects to. */
        enum LightEvent{ BeforeShadowMap = 0, AfterShadowMap = 1, BeforeScreenspaceMask = 2, AfterScreenspaceMask = 3, BeforeShadowMapPass = 4, AfterShadowMapPass = 5 }
        
        /** Allows precise control over which shadow map passes to execute Rendering.CommandBuffer objects attached using Light.AddCommandBuffer. */
        enum ShadowMapPass{ PointlightPositiveX = 1, PointlightNegativeX = 2, PointlightPositiveY = 4, PointlightNegativeY = 8, PointlightPositiveZ = 16, PointlightNegativeZ = 32, DirectionalCascade0 = 64, DirectionalCascade1 = 128, DirectionalCascade2 = 256, DirectionalCascade3 = 512, Spotlight = 1024, Pointlight = 63, Directional = 960, All = 2047 }
        
        
    }
    namespace UnityEngine.ParticleSystem {
        
        class Particle extends System.ValueType{ 
            
        }
        
        
        class PlaybackState extends System.ValueType{ 
            
        }
        
        
        class Trails extends System.ValueType{ 
            
        }
        
        
        class EmitParams extends System.ValueType{ 
            
        }
        
        
        class MainModule extends System.ValueType{ 
            
        }
        
        
        class EmissionModule extends System.ValueType{ 
            
        }
        
        
        class ShapeModule extends System.ValueType{ 
            
        }
        
        
        class VelocityOverLifetimeModule extends System.ValueType{ 
            
        }
        
        
        class LimitVelocityOverLifetimeModule extends System.ValueType{ 
            
        }
        
        
        class InheritVelocityModule extends System.ValueType{ 
            
        }
        
        
        class LifetimeByEmitterSpeedModule extends System.ValueType{ 
            
        }
        
        
        class ForceOverLifetimeModule extends System.ValueType{ 
            
        }
        
        
        class ColorOverLifetimeModule extends System.ValueType{ 
            
        }
        
        
        class ColorBySpeedModule extends System.ValueType{ 
            
        }
        
        
        class SizeOverLifetimeModule extends System.ValueType{ 
            
        }
        
        
        class SizeBySpeedModule extends System.ValueType{ 
            
        }
        
        
        class RotationOverLifetimeModule extends System.ValueType{ 
            
        }
        
        
        class RotationBySpeedModule extends System.ValueType{ 
            
        }
        
        
        class ExternalForcesModule extends System.ValueType{ 
            
        }
        
        
        class NoiseModule extends System.ValueType{ 
            
        }
        
        
        class CollisionModule extends System.ValueType{ 
            
        }
        
        
        class TriggerModule extends System.ValueType{ 
            
        }
        
        
        class SubEmittersModule extends System.ValueType{ 
            
        }
        
        
        class TextureSheetAnimationModule extends System.ValueType{ 
            
        }
        
        
        class LightsModule extends System.ValueType{ 
            
        }
        
        
        class TrailModule extends System.ValueType{ 
            
        }
        
        
        class CustomDataModule extends System.ValueType{ 
            
        }
        
        
    }
    namespace Unity.Collections {
        
        class NativeArray$1<T> extends System.ValueType implements System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.IDisposable, System.IEquatable$1<Unity.Collections.NativeArray$1<T>>{ 
            
        }
        
        
    }
    namespace UnityEngine.RectTransform {
        
        interface ReapplyDrivenProperties { (driven: UnityEngine.RectTransform) : void; } 
        var ReapplyDrivenProperties: {new (func: (driven: UnityEngine.RectTransform) => void): ReapplyDrivenProperties;}
        
        
        enum Edge{ Left = 0, Right = 1, Top = 2, Bottom = 3 }
        
        
        enum Axis{ Horizontal = 0, Vertical = 1 }
        
        
    }
    namespace UnityEngine.UI {
        
        class Image extends UnityEngine.UI.MaskableGraphic implements UnityEngine.UI.IMaterialModifier, UnityEngine.UI.IMaskable, UnityEngine.ICanvasRaycastFilter, UnityEngine.UI.ICanvasElement, UnityEngine.ISerializationCallbackReceiver, UnityEngine.UI.ILayoutElement, UnityEngine.UI.IClippable{ 
            
            public get sprite(): UnityEngine.Sprite;
            public set sprite(value: UnityEngine.Sprite);
            
            public get overrideSprite(): UnityEngine.Sprite;
            public set overrideSprite(value: UnityEngine.Sprite);
            
            public get type(): UnityEngine.UI.Image.Type;
            public set type(value: UnityEngine.UI.Image.Type);
            
            public get preserveAspect(): boolean;
            public set preserveAspect(value: boolean);
            
            public get fillCenter(): boolean;
            public set fillCenter(value: boolean);
            
            public get fillMethod(): UnityEngine.UI.Image.FillMethod;
            public set fillMethod(value: UnityEngine.UI.Image.FillMethod);
            
            public get fillAmount(): number;
            public set fillAmount(value: number);
            
            public get fillClockwise(): boolean;
            public set fillClockwise(value: boolean);
            
            public get fillOrigin(): number;
            public set fillOrigin(value: number);
            
            public get alphaHitTestMinimumThreshold(): number;
            public set alphaHitTestMinimumThreshold(value: number);
            
            public get useSpriteMesh(): boolean;
            public set useSpriteMesh(value: boolean);
            
            public static get defaultETC1GraphicMaterial(): UnityEngine.Material;
            
            
            public get mainTexture(): UnityEngine.Texture;
            
            
            public get hasBorder(): boolean;
            
            
            public get pixelsPerUnitMultiplier(): number;
            public set pixelsPerUnitMultiplier(value: number);
            
            public get pixelsPerUnit(): number;
            
            
            public get material(): UnityEngine.Material;
            public set material(value: UnityEngine.Material);
            
            public get minWidth(): number;
            
            
            public get preferredWidth(): number;
            
            
            public get flexibleWidth(): number;
            
            
            public get minHeight(): number;
            
            
            public get preferredHeight(): number;
            
            
            public get flexibleHeight(): number;
            
            
            public get layoutPriority(): number;
            
            
            public DisableSpriteOptimizations():void;
            
            public OnBeforeSerialize():void;
            
            public OnAfterDeserialize():void;
            
            public CalculateLayoutInputHorizontal():void;
            
            public CalculateLayoutInputVertical():void;
            
            public IsRaycastLocationValid($screenPoint: UnityEngine.Vector2, $eventCamera: UnityEngine.Camera):boolean;
            
        }
        
        
        class MaskableGraphic extends UnityEngine.UI.Graphic implements UnityEngine.UI.IMaterialModifier, UnityEngine.UI.IMaskable, UnityEngine.UI.ICanvasElement, UnityEngine.UI.IClippable{ 
            
        }
        
        
        class Graphic extends UnityEngine.EventSystems.UIBehaviour implements UnityEngine.UI.ICanvasElement{ 
            
        }
        
        
        interface ICanvasElement{ 
            
        }
        
        
        interface IMaterialModifier{ 
            
        }
        
        
        interface IMaskable{ 
            
        }
        
        
        interface IClippable{ 
            
        }
        
        
        interface ILayoutElement{ 
            
        }
        
        
        class RawImage extends UnityEngine.UI.MaskableGraphic implements UnityEngine.UI.IMaterialModifier, UnityEngine.UI.IMaskable, UnityEngine.UI.ICanvasElement, UnityEngine.UI.IClippable{ 
            
            public get mainTexture(): UnityEngine.Texture;
            
            
            public get texture(): UnityEngine.Texture;
            public set texture(value: UnityEngine.Texture);
            
            public get uvRect(): UnityEngine.Rect;
            public set uvRect(value: UnityEngine.Rect);
            
        }
        
        
        class Toggle extends UnityEngine.UI.Selectable implements UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler, UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler{ 
            
            public toggleTransition: UnityEngine.UI.Toggle.ToggleTransition;
            
            public graphic: UnityEngine.UI.Graphic;
            
            public onValueChanged: UnityEngine.UI.Toggle.ToggleEvent;
            
            public get group(): UnityEngine.UI.ToggleGroup;
            public set group(value: UnityEngine.UI.ToggleGroup);
            
            public get isOn(): boolean;
            public set isOn(value: boolean);
            
            public Rebuild($executing: UnityEngine.UI.CanvasUpdate):void;
            
            public LayoutComplete():void;
            
            public GraphicUpdateComplete():void;
            
            public SetIsOnWithoutNotify($value: boolean):void;
            
            public OnPointerClick($eventData: UnityEngine.EventSystems.PointerEventData):void;
            
            public OnSubmit($eventData: UnityEngine.EventSystems.BaseEventData):void;
            
        }
        
        
        class Selectable extends UnityEngine.EventSystems.UIBehaviour implements UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler{ 
            
        }
        
        
        class ToggleGroup extends UnityEngine.EventSystems.UIBehaviour{ 
            
        }
        
        
        enum CanvasUpdate{ Prelayout = 0, Layout = 1, PostLayout = 2, PreRender = 3, LatePreRender = 4, MaxUpdateValue = 5 }
        
        
        class Slider extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler{ 
            
            public get fillRect(): UnityEngine.RectTransform;
            public set fillRect(value: UnityEngine.RectTransform);
            
            public get handleRect(): UnityEngine.RectTransform;
            public set handleRect(value: UnityEngine.RectTransform);
            
            public get direction(): UnityEngine.UI.Slider.Direction;
            public set direction(value: UnityEngine.UI.Slider.Direction);
            
            public get minValue(): number;
            public set minValue(value: number);
            
            public get maxValue(): number;
            public set maxValue(value: number);
            
            public get wholeNumbers(): boolean;
            public set wholeNumbers(value: boolean);
            
            public get value(): number;
            public set value(value: number);
            
            public get normalizedValue(): number;
            public set normalizedValue(value: number);
            
            public get onValueChanged(): UnityEngine.UI.Slider.SliderEvent;
            public set onValueChanged(value: UnityEngine.UI.Slider.SliderEvent);
            
            public SetValueWithoutNotify($input: number):void;
            
            public Rebuild($executing: UnityEngine.UI.CanvasUpdate):void;
            
            public LayoutComplete():void;
            
            public GraphicUpdateComplete():void;
            
            public OnDrag($eventData: UnityEngine.EventSystems.PointerEventData):void;
            
            public OnInitializePotentialDrag($eventData: UnityEngine.EventSystems.PointerEventData):void;
            
            public SetDirection($direction: UnityEngine.UI.Slider.Direction, $includeRectLayouts: boolean):void;
            
        }
        
        
        class Scrollbar extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler{ 
            
        }
        
        
    }
    namespace UnityEngine.EventSystems {
        
        class UIBehaviour extends UnityEngine.MonoBehaviour{ 
            
        }
        
        
        interface IEventSystemHandler{ 
            
        }
        
        
        interface IPointerEnterHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface ISelectHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface IPointerExitHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface IDeselectHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface IPointerDownHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface IPointerUpHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface IMoveHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface ISubmitHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface IPointerClickHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        class PointerEventData extends UnityEngine.EventSystems.BaseEventData{ 
            
        }
        
        
        class BaseEventData extends UnityEngine.EventSystems.AbstractEventData{ 
            
        }
        
        
        class AbstractEventData extends System.Object{ 
            
        }
        
        
        interface IInitializePotentialDragHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface IDragHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        class AxisEventData extends UnityEngine.EventSystems.BaseEventData{ 
            
        }
        
        
        interface ICancelHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface IBeginDragHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface IEndDragHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface IScrollHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
        interface IUpdateSelectedHandler extends UnityEngine.EventSystems.IEventSystemHandler{ 
            
        }
        
        
    }
    namespace UnityEngine.UI.Image {
        
        enum Type{ Simple = 0, Sliced = 1, Tiled = 2, Filled = 3 }
        
        
        enum FillMethod{ Horizontal = 0, Vertical = 1, Radial90 = 2, Radial180 = 3, Radial360 = 4 }
        
        
    }
    namespace UnityEngine.UI.Toggle {
        
        enum ToggleTransition{ None = 0, Fade = 1 }
        
        
        class ToggleEvent extends UnityEngine.Events.UnityEvent$1<boolean> implements UnityEngine.ISerializationCallbackReceiver{ 
            
        }
        
        
    }
    namespace UnityEngine.Events {
        
        class UnityEvent$1<T0> extends UnityEngine.Events.UnityEventBase implements UnityEngine.ISerializationCallbackReceiver{ 
            
        }
        
        /** Abstract base class for UnityEvents. */
        class UnityEventBase extends System.Object implements UnityEngine.ISerializationCallbackReceiver{ 
            
        }
        
        
        class UnityEvent$3<T0, T1, T2> extends UnityEngine.Events.UnityEventBase implements UnityEngine.ISerializationCallbackReceiver{ 
            
        }
        
        
    }
    namespace UnityEngine.UI.Slider {
        
        enum Direction{ LeftToRight = 0, RightToLeft = 1, BottomToTop = 2, TopToBottom = 3 }
        
        
        class SliderEvent extends UnityEngine.Events.UnityEvent$1<number> implements UnityEngine.ISerializationCallbackReceiver{ 
            
        }
        
        
    }
    namespace TMPro {
        
        class TMP_Text extends UnityEngine.UI.MaskableGraphic implements UnityEngine.UI.IMaterialModifier, UnityEngine.UI.IMaskable, UnityEngine.UI.ICanvasElement, UnityEngine.UI.IClippable{ 
            
            public get text(): string;
            public set text(value: string);
            
            public get textPreprocessor(): TMPro.ITextPreprocessor;
            public set textPreprocessor(value: TMPro.ITextPreprocessor);
            
            public get isRightToLeftText(): boolean;
            public set isRightToLeftText(value: boolean);
            
            public get font(): TMPro.TMP_FontAsset;
            public set font(value: TMPro.TMP_FontAsset);
            
            public get fontSharedMaterial(): UnityEngine.Material;
            public set fontSharedMaterial(value: UnityEngine.Material);
            
            public get fontSharedMaterials(): System.Array$1<UnityEngine.Material>;
            public set fontSharedMaterials(value: System.Array$1<UnityEngine.Material>);
            
            public get fontMaterial(): UnityEngine.Material;
            public set fontMaterial(value: UnityEngine.Material);
            
            public get fontMaterials(): System.Array$1<UnityEngine.Material>;
            public set fontMaterials(value: System.Array$1<UnityEngine.Material>);
            
            public get color(): UnityEngine.Color;
            public set color(value: UnityEngine.Color);
            
            public get alpha(): number;
            public set alpha(value: number);
            
            public get enableVertexGradient(): boolean;
            public set enableVertexGradient(value: boolean);
            
            public get colorGradient(): TMPro.VertexGradient;
            public set colorGradient(value: TMPro.VertexGradient);
            
            public get colorGradientPreset(): TMPro.TMP_ColorGradient;
            public set colorGradientPreset(value: TMPro.TMP_ColorGradient);
            
            public get spriteAsset(): TMPro.TMP_SpriteAsset;
            public set spriteAsset(value: TMPro.TMP_SpriteAsset);
            
            public get tintAllSprites(): boolean;
            public set tintAllSprites(value: boolean);
            
            public get styleSheet(): TMPro.TMP_StyleSheet;
            public set styleSheet(value: TMPro.TMP_StyleSheet);
            
            public get textStyle(): TMPro.TMP_Style;
            public set textStyle(value: TMPro.TMP_Style);
            
            public get overrideColorTags(): boolean;
            public set overrideColorTags(value: boolean);
            
            public get faceColor(): UnityEngine.Color32;
            public set faceColor(value: UnityEngine.Color32);
            
            public get outlineColor(): UnityEngine.Color32;
            public set outlineColor(value: UnityEngine.Color32);
            
            public get outlineWidth(): number;
            public set outlineWidth(value: number);
            
            public get fontSize(): number;
            public set fontSize(value: number);
            
            public get fontWeight(): TMPro.FontWeight;
            public set fontWeight(value: TMPro.FontWeight);
            
            public get pixelsPerUnit(): number;
            
            
            public get enableAutoSizing(): boolean;
            public set enableAutoSizing(value: boolean);
            
            public get fontSizeMin(): number;
            public set fontSizeMin(value: number);
            
            public get fontSizeMax(): number;
            public set fontSizeMax(value: number);
            
            public get fontStyle(): TMPro.FontStyles;
            public set fontStyle(value: TMPro.FontStyles);
            
            public get isUsingBold(): boolean;
            
            
            public get horizontalAlignment(): TMPro.HorizontalAlignmentOptions;
            public set horizontalAlignment(value: TMPro.HorizontalAlignmentOptions);
            
            public get verticalAlignment(): TMPro.VerticalAlignmentOptions;
            public set verticalAlignment(value: TMPro.VerticalAlignmentOptions);
            
            public get alignment(): TMPro.TextAlignmentOptions;
            public set alignment(value: TMPro.TextAlignmentOptions);
            
            public get characterSpacing(): number;
            public set characterSpacing(value: number);
            
            public get wordSpacing(): number;
            public set wordSpacing(value: number);
            
            public get lineSpacing(): number;
            public set lineSpacing(value: number);
            
            public get lineSpacingAdjustment(): number;
            public set lineSpacingAdjustment(value: number);
            
            public get paragraphSpacing(): number;
            public set paragraphSpacing(value: number);
            
            public get characterWidthAdjustment(): number;
            public set characterWidthAdjustment(value: number);
            
            public get enableWordWrapping(): boolean;
            public set enableWordWrapping(value: boolean);
            
            public get wordWrappingRatios(): number;
            public set wordWrappingRatios(value: number);
            
            public get overflowMode(): TMPro.TextOverflowModes;
            public set overflowMode(value: TMPro.TextOverflowModes);
            
            public get isTextOverflowing(): boolean;
            
            
            public get firstOverflowCharacterIndex(): number;
            
            
            public get linkedTextComponent(): TMPro.TMP_Text;
            public set linkedTextComponent(value: TMPro.TMP_Text);
            
            public get isTextTruncated(): boolean;
            
            
            public get enableKerning(): boolean;
            public set enableKerning(value: boolean);
            
            public get extraPadding(): boolean;
            public set extraPadding(value: boolean);
            
            public get richText(): boolean;
            public set richText(value: boolean);
            
            public get parseCtrlCharacters(): boolean;
            public set parseCtrlCharacters(value: boolean);
            
            public get isOverlay(): boolean;
            public set isOverlay(value: boolean);
            
            public get isOrthographic(): boolean;
            public set isOrthographic(value: boolean);
            
            public get enableCulling(): boolean;
            public set enableCulling(value: boolean);
            
            public get ignoreVisibility(): boolean;
            public set ignoreVisibility(value: boolean);
            
            public get horizontalMapping(): TMPro.TextureMappingOptions;
            public set horizontalMapping(value: TMPro.TextureMappingOptions);
            
            public get verticalMapping(): TMPro.TextureMappingOptions;
            public set verticalMapping(value: TMPro.TextureMappingOptions);
            
            public get mappingUvLineOffset(): number;
            public set mappingUvLineOffset(value: number);
            
            public get renderMode(): TMPro.TextRenderFlags;
            public set renderMode(value: TMPro.TextRenderFlags);
            
            public get geometrySortingOrder(): TMPro.VertexSortingOrder;
            public set geometrySortingOrder(value: TMPro.VertexSortingOrder);
            
            public get isTextObjectScaleStatic(): boolean;
            public set isTextObjectScaleStatic(value: boolean);
            
            public get vertexBufferAutoSizeReduction(): boolean;
            public set vertexBufferAutoSizeReduction(value: boolean);
            
            public get firstVisibleCharacter(): number;
            public set firstVisibleCharacter(value: number);
            
            public get maxVisibleCharacters(): number;
            public set maxVisibleCharacters(value: number);
            
            public get maxVisibleWords(): number;
            public set maxVisibleWords(value: number);
            
            public get maxVisibleLines(): number;
            public set maxVisibleLines(value: number);
            
            public get useMaxVisibleDescender(): boolean;
            public set useMaxVisibleDescender(value: boolean);
            
            public get pageToDisplay(): number;
            public set pageToDisplay(value: number);
            
            public get margin(): UnityEngine.Vector4;
            public set margin(value: UnityEngine.Vector4);
            
            public get textInfo(): TMPro.TMP_TextInfo;
            
            
            public get havePropertiesChanged(): boolean;
            public set havePropertiesChanged(value: boolean);
            
            public get isUsingLegacyAnimationComponent(): boolean;
            public set isUsingLegacyAnimationComponent(value: boolean);
            
            public get transform(): UnityEngine.Transform;
            
            
            public get rectTransform(): UnityEngine.RectTransform;
            
            
            public get autoSizeTextContainer(): boolean;
            public set autoSizeTextContainer(value: boolean);
            
            public get mesh(): UnityEngine.Mesh;
            
            
            public get isVolumetricText(): boolean;
            public set isVolumetricText(value: boolean);
            
            public get bounds(): UnityEngine.Bounds;
            
            
            public get textBounds(): UnityEngine.Bounds;
            
            
            public get flexibleHeight(): number;
            
            
            public get flexibleWidth(): number;
            
            
            public get minWidth(): number;
            
            
            public get minHeight(): number;
            
            
            public get maxWidth(): number;
            
            
            public get maxHeight(): number;
            
            
            public get preferredWidth(): number;
            
            
            public get preferredHeight(): number;
            
            
            public get renderedWidth(): number;
            
            
            public get renderedHeight(): number;
            
            
            public get layoutPriority(): number;
            
            
            public static add_OnFontAssetRequest($value: System.Func$3<number, string, TMPro.TMP_FontAsset>):void;
            
            public static remove_OnFontAssetRequest($value: System.Func$3<number, string, TMPro.TMP_FontAsset>):void;
            
            public static add_OnSpriteAssetRequest($value: System.Func$3<number, string, TMPro.TMP_SpriteAsset>):void;
            
            public static remove_OnSpriteAssetRequest($value: System.Func$3<number, string, TMPro.TMP_SpriteAsset>):void;
            
            public add_OnPreRenderText($value: System.Action$1<TMPro.TMP_TextInfo>):void;
            
            public remove_OnPreRenderText($value: System.Action$1<TMPro.TMP_TextInfo>):void;
            
            public ForceMeshUpdate($ignoreActiveState?: boolean, $forceTextReparsing?: boolean):void;
            
            public UpdateGeometry($mesh: UnityEngine.Mesh, $index: number):void;
            
            public UpdateVertexData($flags: TMPro.TMP_VertexDataUpdateFlags):void;
            
            public UpdateVertexData():void;
            
            public SetVertices($vertices: System.Array$1<UnityEngine.Vector3>):void;
            
            public UpdateMeshPadding():void;
            
            public SetText($sourceText: string, $syncTextInputBox?: boolean):void;
            
            public SetText($sourceText: string, $arg0: number):void;
            
            public SetText($sourceText: string, $arg0: number, $arg1: number):void;
            
            public SetText($sourceText: string, $arg0: number, $arg1: number, $arg2: number):void;
            
            public SetText($sourceText: string, $arg0: number, $arg1: number, $arg2: number, $arg3: number):void;
            
            public SetText($sourceText: string, $arg0: number, $arg1: number, $arg2: number, $arg3: number, $arg4: number):void;
            
            public SetText($sourceText: string, $arg0: number, $arg1: number, $arg2: number, $arg3: number, $arg4: number, $arg5: number):void;
            
            public SetText($sourceText: string, $arg0: number, $arg1: number, $arg2: number, $arg3: number, $arg4: number, $arg5: number, $arg6: number):void;
            
            public SetText($sourceText: string, $arg0: number, $arg1: number, $arg2: number, $arg3: number, $arg4: number, $arg5: number, $arg6: number, $arg7: number):void;
            
            public SetText($sourceText: System.Text.StringBuilder):void;
            
            public SetText($sourceText: System.Array$1<number>):void;
            
            public SetText($sourceText: System.Array$1<number>, $start: number, $length: number):void;
            
            public SetCharArray($sourceText: System.Array$1<number>):void;
            
            public SetCharArray($sourceText: System.Array$1<number>, $start: number, $length: number):void;
            
            public GetPreferredValues():UnityEngine.Vector2;
            
            public GetPreferredValues($width: number, $height: number):UnityEngine.Vector2;
            
            public GetPreferredValues($text: string):UnityEngine.Vector2;
            
            public GetPreferredValues($text: string, $width: number, $height: number):UnityEngine.Vector2;
            
            public GetRenderedValues():UnityEngine.Vector2;
            
            public GetRenderedValues($onlyVisibleCharacters: boolean):UnityEngine.Vector2;
            
            public GetTextInfo($text: string):TMPro.TMP_TextInfo;
            
            public ComputeMarginSize():void;
            
            public ClearMesh():void;
            
            public ClearMesh($uploadGeometry: boolean):void;
            
            public GetParsedText():string;
            
        }
        
        
        interface ITextPreprocessor{ 
            
        }
        
        
        class TMP_FontAsset extends TMPro.TMP_Asset{ 
            
        }
        
        
        class TMP_Asset extends UnityEngine.ScriptableObject{ 
            
        }
        
        
        class VertexGradient extends System.ValueType{ 
            
        }
        
        
        class TMP_ColorGradient extends UnityEngine.ScriptableObject{ 
            
        }
        
        
        class TMP_SpriteAsset extends TMPro.TMP_Asset{ 
            
        }
        
        
        class TMP_StyleSheet extends UnityEngine.ScriptableObject{ 
            
        }
        
        
        class TMP_Style extends System.Object{ 
            
        }
        
        
        enum FontWeight{ Thin = 100, ExtraLight = 200, Light = 300, Regular = 400, Medium = 500, SemiBold = 600, Bold = 700, Heavy = 800, Black = 900 }
        
        
        enum FontStyles{ Normal = 0, Bold = 1, Italic = 2, Underline = 4, LowerCase = 8, UpperCase = 16, SmallCaps = 32, Strikethrough = 64, Superscript = 128, Subscript = 256, Highlight = 512 }
        
        
        enum HorizontalAlignmentOptions{ Left = 1, Center = 2, Right = 4, Justified = 8, Flush = 16, Geometry = 32 }
        
        
        enum VerticalAlignmentOptions{ Top = 256, Middle = 512, Bottom = 1024, Baseline = 2048, Geometry = 4096, Capline = 8192 }
        
        
        enum TextAlignmentOptions{ TopLeft = 257, Top = 258, TopRight = 260, TopJustified = 264, TopFlush = 272, TopGeoAligned = 288, Left = 513, Center = 514, Right = 516, Justified = 520, Flush = 528, CenterGeoAligned = 544, BottomLeft = 1025, Bottom = 1026, BottomRight = 1028, BottomJustified = 1032, BottomFlush = 1040, BottomGeoAligned = 1056, BaselineLeft = 2049, Baseline = 2050, BaselineRight = 2052, BaselineJustified = 2056, BaselineFlush = 2064, BaselineGeoAligned = 2080, MidlineLeft = 4097, Midline = 4098, MidlineRight = 4100, MidlineJustified = 4104, MidlineFlush = 4112, MidlineGeoAligned = 4128, CaplineLeft = 8193, Capline = 8194, CaplineRight = 8196, CaplineJustified = 8200, CaplineFlush = 8208, CaplineGeoAligned = 8224, Converted = 65535 }
        
        
        enum TextOverflowModes{ Overflow = 0, Ellipsis = 1, Masking = 2, Truncate = 3, ScrollRect = 4, Page = 5, Linked = 6 }
        
        
        enum TextureMappingOptions{ Character = 0, Line = 1, Paragraph = 2, MatchAspect = 3 }
        
        
        enum TextRenderFlags{ DontRender = 0, Render = 255 }
        
        
        enum VertexSortingOrder{ Normal = 0, Reverse = 1 }
        
        
        class TMP_TextInfo extends System.Object{ 
            
        }
        
        
        enum TMP_VertexDataUpdateFlags{ None = 0, Vertices = 1, Uv0 = 2, Uv2 = 4, Uv4 = 8, Colors32 = 16, All = 255 }
        
        
        class TMP_Dropdown extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.ICancelHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler, UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler{ 
            
            public get template(): UnityEngine.RectTransform;
            public set template(value: UnityEngine.RectTransform);
            
            public get captionText(): TMPro.TMP_Text;
            public set captionText(value: TMPro.TMP_Text);
            
            public get captionImage(): UnityEngine.UI.Image;
            public set captionImage(value: UnityEngine.UI.Image);
            
            public get placeholder(): UnityEngine.UI.Graphic;
            public set placeholder(value: UnityEngine.UI.Graphic);
            
            public get itemText(): TMPro.TMP_Text;
            public set itemText(value: TMPro.TMP_Text);
            
            public get itemImage(): UnityEngine.UI.Image;
            public set itemImage(value: UnityEngine.UI.Image);
            
            public get options(): System.Collections.Generic.List$1<TMPro.TMP_Dropdown.OptionData>;
            public set options(value: System.Collections.Generic.List$1<TMPro.TMP_Dropdown.OptionData>);
            
            public get onValueChanged(): TMPro.TMP_Dropdown.DropdownEvent;
            public set onValueChanged(value: TMPro.TMP_Dropdown.DropdownEvent);
            
            public get alphaFadeSpeed(): number;
            public set alphaFadeSpeed(value: number);
            
            public get value(): number;
            public set value(value: number);
            
            public get IsExpanded(): boolean;
            
            
            public SetValueWithoutNotify($input: number):void;
            
            public RefreshShownValue():void;
            
            public AddOptions($options: System.Collections.Generic.List$1<TMPro.TMP_Dropdown.OptionData>):void;
            
            public AddOptions($options: System.Collections.Generic.List$1<string>):void;
            
            public AddOptions($options: System.Collections.Generic.List$1<UnityEngine.Sprite>):void;
            
            public ClearOptions():void;
            
            public OnPointerClick($eventData: UnityEngine.EventSystems.PointerEventData):void;
            
            public OnSubmit($eventData: UnityEngine.EventSystems.BaseEventData):void;
            
            public OnCancel($eventData: UnityEngine.EventSystems.BaseEventData):void;
            
            public Show():void;
            
            public Hide():void;
            
        }
        
        
        class TMP_InputField extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.IEndDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IScrollHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.IUpdateSelectedHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler, UnityEngine.UI.ILayoutElement, UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler{ 
            
            public get shouldHideMobileInput(): boolean;
            public set shouldHideMobileInput(value: boolean);
            
            public get shouldHideSoftKeyboard(): boolean;
            public set shouldHideSoftKeyboard(value: boolean);
            
            public get text(): string;
            public set text(value: string);
            
            public get isFocused(): boolean;
            
            
            public get caretBlinkRate(): number;
            public set caretBlinkRate(value: number);
            
            public get caretWidth(): number;
            public set caretWidth(value: number);
            
            public get textViewport(): UnityEngine.RectTransform;
            public set textViewport(value: UnityEngine.RectTransform);
            
            public get textComponent(): TMPro.TMP_Text;
            public set textComponent(value: TMPro.TMP_Text);
            
            public get placeholder(): UnityEngine.UI.Graphic;
            public set placeholder(value: UnityEngine.UI.Graphic);
            
            public get verticalScrollbar(): UnityEngine.UI.Scrollbar;
            public set verticalScrollbar(value: UnityEngine.UI.Scrollbar);
            
            public get scrollSensitivity(): number;
            public set scrollSensitivity(value: number);
            
            public get caretColor(): UnityEngine.Color;
            public set caretColor(value: UnityEngine.Color);
            
            public get customCaretColor(): boolean;
            public set customCaretColor(value: boolean);
            
            public get selectionColor(): UnityEngine.Color;
            public set selectionColor(value: UnityEngine.Color);
            
            public get onEndEdit(): TMPro.TMP_InputField.SubmitEvent;
            public set onEndEdit(value: TMPro.TMP_InputField.SubmitEvent);
            
            public get onSubmit(): TMPro.TMP_InputField.SubmitEvent;
            public set onSubmit(value: TMPro.TMP_InputField.SubmitEvent);
            
            public get onSelect(): TMPro.TMP_InputField.SelectionEvent;
            public set onSelect(value: TMPro.TMP_InputField.SelectionEvent);
            
            public get onDeselect(): TMPro.TMP_InputField.SelectionEvent;
            public set onDeselect(value: TMPro.TMP_InputField.SelectionEvent);
            
            public get onTextSelection(): TMPro.TMP_InputField.TextSelectionEvent;
            public set onTextSelection(value: TMPro.TMP_InputField.TextSelectionEvent);
            
            public get onEndTextSelection(): TMPro.TMP_InputField.TextSelectionEvent;
            public set onEndTextSelection(value: TMPro.TMP_InputField.TextSelectionEvent);
            
            public get onValueChanged(): TMPro.TMP_InputField.OnChangeEvent;
            public set onValueChanged(value: TMPro.TMP_InputField.OnChangeEvent);
            
            public get onTouchScreenKeyboardStatusChanged(): TMPro.TMP_InputField.TouchScreenKeyboardEvent;
            public set onTouchScreenKeyboardStatusChanged(value: TMPro.TMP_InputField.TouchScreenKeyboardEvent);
            
            public get onValidateInput(): TMPro.TMP_InputField.OnValidateInput;
            public set onValidateInput(value: TMPro.TMP_InputField.OnValidateInput);
            
            public get characterLimit(): number;
            public set characterLimit(value: number);
            
            public get pointSize(): number;
            public set pointSize(value: number);
            
            public get fontAsset(): TMPro.TMP_FontAsset;
            public set fontAsset(value: TMPro.TMP_FontAsset);
            
            public get onFocusSelectAll(): boolean;
            public set onFocusSelectAll(value: boolean);
            
            public get resetOnDeActivation(): boolean;
            public set resetOnDeActivation(value: boolean);
            
            public get restoreOriginalTextOnEscape(): boolean;
            public set restoreOriginalTextOnEscape(value: boolean);
            
            public get isRichTextEditingAllowed(): boolean;
            public set isRichTextEditingAllowed(value: boolean);
            
            public get contentType(): TMPro.TMP_InputField.ContentType;
            public set contentType(value: TMPro.TMP_InputField.ContentType);
            
            public get lineType(): TMPro.TMP_InputField.LineType;
            public set lineType(value: TMPro.TMP_InputField.LineType);
            
            public get lineLimit(): number;
            public set lineLimit(value: number);
            
            public get inputType(): TMPro.TMP_InputField.InputType;
            public set inputType(value: TMPro.TMP_InputField.InputType);
            
            public get keyboardType(): UnityEngine.TouchScreenKeyboardType;
            public set keyboardType(value: UnityEngine.TouchScreenKeyboardType);
            
            public get characterValidation(): TMPro.TMP_InputField.CharacterValidation;
            public set characterValidation(value: TMPro.TMP_InputField.CharacterValidation);
            
            public get inputValidator(): TMPro.TMP_InputValidator;
            public set inputValidator(value: TMPro.TMP_InputValidator);
            
            public get readOnly(): boolean;
            public set readOnly(value: boolean);
            
            public get richText(): boolean;
            public set richText(value: boolean);
            
            public get multiLine(): boolean;
            
            
            public get asteriskChar(): number;
            public set asteriskChar(value: number);
            
            public get wasCanceled(): boolean;
            
            
            public get caretPosition(): number;
            public set caretPosition(value: number);
            
            public get selectionAnchorPosition(): number;
            public set selectionAnchorPosition(value: number);
            
            public get selectionFocusPosition(): number;
            public set selectionFocusPosition(value: number);
            
            public get stringPosition(): number;
            public set stringPosition(value: number);
            
            public get selectionStringAnchorPosition(): number;
            public set selectionStringAnchorPosition(value: number);
            
            public get selectionStringFocusPosition(): number;
            public set selectionStringFocusPosition(value: number);
            
            public get minWidth(): number;
            
            
            public get preferredWidth(): number;
            
            
            public get flexibleWidth(): number;
            
            
            public get minHeight(): number;
            
            
            public get preferredHeight(): number;
            
            
            public get flexibleHeight(): number;
            
            
            public get layoutPriority(): number;
            
            
            public SetTextWithoutNotify($input: string):void;
            
            public MoveTextEnd($shift: boolean):void;
            
            public MoveTextStart($shift: boolean):void;
            
            public MoveToEndOfLine($shift: boolean, $ctrl: boolean):void;
            
            public MoveToStartOfLine($shift: boolean, $ctrl: boolean):void;
            
            public OnBeginDrag($eventData: UnityEngine.EventSystems.PointerEventData):void;
            
            public OnDrag($eventData: UnityEngine.EventSystems.PointerEventData):void;
            
            public OnEndDrag($eventData: UnityEngine.EventSystems.PointerEventData):void;
            
            public ProcessEvent($e: UnityEngine.Event):void;
            
            public OnUpdateSelected($eventData: UnityEngine.EventSystems.BaseEventData):void;
            
            public OnScroll($eventData: UnityEngine.EventSystems.PointerEventData):void;
            
            public ForceLabelUpdate():void;
            
            public Rebuild($update: UnityEngine.UI.CanvasUpdate):void;
            
            public LayoutComplete():void;
            
            public GraphicUpdateComplete():void;
            
            public ActivateInputField():void;
            
            public OnPointerClick($eventData: UnityEngine.EventSystems.PointerEventData):void;
            
            public OnControlClick():void;
            
            public ReleaseSelection():void;
            
            public DeactivateInputField($clearSelection?: boolean):void;
            
            public OnSubmit($eventData: UnityEngine.EventSystems.BaseEventData):void;
            
            public CalculateLayoutInputHorizontal():void;
            
            public CalculateLayoutInputVertical():void;
            
            public SetGlobalPointSize($pointSize: number):void;
            
            public SetGlobalFontAsset($fontAsset: TMPro.TMP_FontAsset):void;
            
        }
        
        
        class TMP_InputValidator extends UnityEngine.ScriptableObject{ 
            
        }
        
        
    }
    namespace System.Text {
        
        class StringBuilder extends System.Object implements System.Runtime.Serialization.ISerializable{ 
            
        }
        
        
    }
    namespace TMPro.TMP_Dropdown {
        
        class OptionData extends System.Object{ 
            
        }
        
        
        class DropdownEvent extends UnityEngine.Events.UnityEvent$1<number> implements UnityEngine.ISerializationCallbackReceiver{ 
            
        }
        
        
    }
    namespace TMPro.TMP_InputField {
        
        class SubmitEvent extends UnityEngine.Events.UnityEvent$1<string> implements UnityEngine.ISerializationCallbackReceiver{ 
            
        }
        
        
        class SelectionEvent extends UnityEngine.Events.UnityEvent$1<string> implements UnityEngine.ISerializationCallbackReceiver{ 
            
        }
        
        
        class TextSelectionEvent extends UnityEngine.Events.UnityEvent$3<string, number, number> implements UnityEngine.ISerializationCallbackReceiver{ 
            
        }
        
        
        class OnChangeEvent extends UnityEngine.Events.UnityEvent$1<string> implements UnityEngine.ISerializationCallbackReceiver{ 
            
        }
        
        
        class TouchScreenKeyboardEvent extends UnityEngine.Events.UnityEvent$1<UnityEngine.TouchScreenKeyboard.Status> implements UnityEngine.ISerializationCallbackReceiver{ 
            
        }
        
        
        interface OnValidateInput { (text: string, charIndex: number, addedChar: number) : number; } 
        var OnValidateInput: {new (func: (text: string, charIndex: number, addedChar: number) => number): OnValidateInput;}
        
        
        enum ContentType{ Standard = 0, Autocorrected = 1, IntegerNumber = 2, DecimalNumber = 3, Alphanumeric = 4, Name = 5, EmailAddress = 6, Password = 7, Pin = 8, Custom = 9 }
        
        
        enum LineType{ SingleLine = 0, MultiLineSubmit = 1, MultiLineNewline = 2 }
        
        
        enum InputType{ Standard = 0, AutoCorrect = 1, Password = 2 }
        
        
        enum CharacterValidation{ None = 0, Digit = 1, Integer = 2, Decimal = 3, Alphanumeric = 4, Name = 5, Regex = 6, EmailAddress = 7, CustomValidator = 8 }
        
        
    }
    namespace UnityEngine.TouchScreenKeyboard {
        
        enum Status{ Visible = 0, Done = 1, Canceled = 2, LostFocus = 3 }
        
        
    }
    namespace UnityGameFramework.Runtime.Extension.UUtility {
        
        class Text extends System.Object{ 
            
            public static Format($format: string, $arg: any):string;
            
            public static Format($format: string, $arg1: any, $arg2: any):string;
            
            public static Format($format: string, $arg1: any, $arg2: any, $arg3: any):string;
            
            public static Format($format: string, $arg1: any, $arg2: any, $arg3: any, $arg4: any):string;
            
            public static Format($format: string, $arg1: any, $arg2: any, $arg3: any, $arg4: any, $arg5: any):string;
            
            public static ToLowerFirstChar($s: string):string;
            
            public static ToUpperFirstChar($s: string):string;
            
        }
        
        
        class Asset extends System.Object{ 
            
            public static RPath: string;
            
            public static RScenePath: string;
            
            public static RVideoPath: string;
            
            public static RAudioPath: string;
            
            public static RAudioMusicPath: string;
            
            public static RAudioSoundPath: string;
            
            public static RAudioUISoundPath: string;
            
            public static RTablePath: string;
            
            public static RTableExcelPath: string;
            
            public static RTableClientPath: string;
            
            public static RTableClientDataPath: string;
            
            public static RTableClientScriptPath: string;
            
            public static RTableServerPath: string;
            
            public static RTableServerDataPath: string;
            
            public static RTableServerScriptPath: string;
            
            public static RTableJsonPath: string;
            
            public static RTableLanguagePath: string;
            
            public static RUIPath: string;
            
            public static RUIAtlasPath: string;
            
            public static RUIFontPath: string;
            
            public static RUIEntityPath: string;
            
            public static RUIFormPath: string;
            
            public static RUISpritePath: string;
            
            public static RUITexturePath: string;
            
            public static REffectPath: string;
            
            public static REffectEntityPath: string;
            
            public static REffectPrefabPath: string;
            
            public static REffectAnimationPath: string;
            
            public static REffectAnimatorPath: string;
            
            public static REffectTexturePath: string;
            
            public static REffectMaterialPath: string;
            
            public static RModelPath: string;
            
            public static RModelEntityPath: string;
            
            public static RModelPrefabPath: string;
            
            public static RModelAnimationPath: string;
            
            public static RModelAnimatorPath: string;
            
            public static RModelTexturePath: string;
            
            public static RModelMaterialPath: string;
            
            public static GetScenePath($name: string, $ext?: string):string;
            
            public static GetVideoPath($name: string, $ext?: string):string;
            
            public static GetMusicPath($name: string, $ext?: string):string;
            
            public static GetSoundPath($name: string, $ext?: string):string;
            
            public static GetUISoundPath($name: string, $ext?: string):string;
            
            public static GetTableExcelPath($name: string, $ext?: string):string;
            
            public static GetTableClientDataPath($name: string, $ext?: string):string;
            
            public static GetTableClientScriptPath($name: string, $ext?: string):string;
            
            public static GetTableServerDataPath($name: string, $ext?: string):string;
            
            public static GetTableServerScriptPath($name: string, $ext?: string):string;
            
            public static GetTableJsonPath($name: string, $ext?: string):string;
            
            public static GetTableLanguagePath($name: string, $ext?: string):string;
            
            public static GetUIAtlasSpritePath($atlasName: string, $spriteName: string, $ext?: string):string;
            
            public static GetUIAtlasPath($name: string, $ext?: string):string;
            
            public static GetUIFontPath($name: string, $ext?: string):string;
            
            public static GetUIItemPath($name: string, $ext?: string):string;
            
            public static GetUIFormPath($name: string, $ext?: string):string;
            
            public static GetUISpritePath($name: string, $ext?: string):string;
            
            public static GetUITexturePath($name: string, $ext?: string):string;
            
            public static GetEffectPrefabPath($name: string, $ext?: string):string;
            
            public static GetEffectEntityPath($name: string, $ext?: string):string;
            
            public static GetModelPrefabPath($name: string, $ext?: string):string;
            
            public static GetModelEntityPath($name: string, $ext?: string):string;
            
        }
        
        
    }
    namespace UnityGameFramework.Runtime {
        
        class Log extends System.Object{ 
            
            public static Debug($message: any):void;
            
            public static Debug($message: string):void;
            
            public static Info($message: any):void;
            
            public static Info($message: string):void;
            
            public static Warning($message: any):void;
            
            public static Warning($message: string):void;
            
            public static Error($message: any):void;
            
            public static Error($message: string):void;
            
            public static Fatal($message: any):void;
            
            public static Fatal($message: string):void;
            
        }
        
        
        class BaseComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get EditorResourceMode(): boolean;
            public set EditorResourceMode(value: boolean);
            
            public get EditorLanguage(): GameFramework.Localization.Language;
            public set EditorLanguage(value: GameFramework.Localization.Language);
            
            public get EditorResourceHelper(): GameFramework.Resource.IResourceManager;
            public set EditorResourceHelper(value: GameFramework.Resource.IResourceManager);
            
            public get FrameRate(): number;
            public set FrameRate(value: number);
            
            public get GameSpeed(): number;
            public set GameSpeed(value: number);
            
            public get IsGamePaused(): boolean;
            
            
            public get IsNormalGameSpeed(): boolean;
            
            
            public get RunInBackground(): boolean;
            public set RunInBackground(value: boolean);
            
            public get NeverSleep(): boolean;
            public set NeverSleep(value: boolean);
            
            public PauseGame():void;
            
            public ResumeGame():void;
            
            public ResetNormalGameSpeed():void;
            
            public constructor();
            
        }
        
        
        class GameFrameworkComponent extends UnityEngine.MonoBehaviour{ 
            
        }
        
        
        class ConfigComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
        }
        
        
        class DataNodeComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
        }
        
        
        class DataTableComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
        }
        
        
        class DebuggerComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
        }
        
        
        class DownloadComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get Paused(): boolean;
            public set Paused(value: boolean);
            
            public get TotalAgentCount(): number;
            
            
            public get FreeAgentCount(): number;
            
            
            public get WorkingAgentCount(): number;
            
            
            public get WaitingTaskCount(): number;
            
            
            public get Timeout(): number;
            public set Timeout(value: number);
            
            public get FlushSize(): number;
            public set FlushSize(value: number);
            
            public get CurrentSpeed(): number;
            
            
            public GetDownloadInfo($serialId: number):GameFramework.TaskInfo;
            
            public GetDownloadInfos($tag: string):System.Array$1<GameFramework.TaskInfo>;
            
            public GetDownloadInfos($tag: string, $results: System.Collections.Generic.List$1<GameFramework.TaskInfo>):void;
            
            public GetAllDownloadInfos():System.Array$1<GameFramework.TaskInfo>;
            
            public GetAllDownloadInfos($results: System.Collections.Generic.List$1<GameFramework.TaskInfo>):void;
            
            public AddDownload($downloadPath: string, $downloadUri: string):number;
            
            public AddDownload($downloadPath: string, $downloadUri: string, $tag: string):number;
            
            public AddDownload($downloadPath: string, $downloadUri: string, $priority: number):number;
            
            public AddDownload($downloadPath: string, $downloadUri: string, $userData: any):number;
            
            public AddDownload($downloadPath: string, $downloadUri: string, $tag: string, $priority: number):number;
            
            public AddDownload($downloadPath: string, $downloadUri: string, $tag: string, $userData: any):number;
            
            public AddDownload($downloadPath: string, $downloadUri: string, $priority: number, $userData: any):number;
            
            public AddDownload($downloadPath: string, $downloadUri: string, $tag: string, $priority: number, $userData: any):number;
            
            public RemoveDownload($serialId: number):boolean;
            
            public RemoveDownloads($tag: string):number;
            
            public RemoveAllDownloads():number;
            
            public constructor();
            
        }
        
        
        class EntityComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get EntityCount(): number;
            
            
            public get EntityGroupCount(): number;
            
            
            public HasEntityGroup($entityGroupName: string):boolean;
            
            public GetEntityGroup($entityGroupName: string):GameFramework.Entity.IEntityGroup;
            
            public GetAllEntityGroups():System.Array$1<GameFramework.Entity.IEntityGroup>;
            
            public GetAllEntityGroups($results: System.Collections.Generic.List$1<GameFramework.Entity.IEntityGroup>):void;
            
            public AddEntityGroup($entityGroupName: string, $instanceAutoReleaseInterval: number, $instanceCapacity: number, $instanceExpireTime: number, $instancePriority: number):boolean;
            
            public HasEntity($entityId: number):boolean;
            
            public HasEntity($entityAssetName: string):boolean;
            
            public GetEntity($entityId: number):UnityGameFramework.Runtime.Entity;
            
            public GetEntity($entityAssetName: string):UnityGameFramework.Runtime.Entity;
            
            public GetEntities($entityAssetName: string):System.Array$1<UnityGameFramework.Runtime.Entity>;
            
            public GetEntities($entityAssetName: string, $results: System.Collections.Generic.List$1<UnityGameFramework.Runtime.Entity>):void;
            
            public GetAllLoadedEntities():System.Array$1<UnityGameFramework.Runtime.Entity>;
            
            public GetAllLoadedEntities($results: System.Collections.Generic.List$1<UnityGameFramework.Runtime.Entity>):void;
            
            public GetAllLoadingEntityIds():System.Array$1<number>;
            
            public GetAllLoadingEntityIds($results: System.Collections.Generic.List$1<number>):void;
            
            public IsLoadingEntity($entityId: number):boolean;
            
            public IsValidEntity($entity: UnityGameFramework.Runtime.Entity):boolean;
            
            public ShowEntity($entityId: number, $entityLogicType: System.Type, $entityAssetName: string, $entityGroupName: string):void;
            
            public ShowEntity($entityId: number, $entityLogicType: System.Type, $entityAssetName: string, $entityGroupName: string, $priority: number):void;
            
            public ShowEntity($entityId: number, $entityLogicType: System.Type, $entityAssetName: string, $entityGroupName: string, $userData: any):void;
            
            public ShowEntity($entityId: number, $entityLogicType: System.Type, $entityAssetName: string, $entityGroupName: string, $priority: number, $userData: any):void;
            
            public HideEntity($entityId: number):void;
            
            public HideEntity($entityId: number, $userData: any):void;
            
            public HideEntity($entity: UnityGameFramework.Runtime.Entity):void;
            
            public HideEntity($entity: UnityGameFramework.Runtime.Entity, $userData: any):void;
            
            public HideAllLoadedEntities():void;
            
            public HideAllLoadedEntities($userData: any):void;
            
            public HideAllLoadingEntities():void;
            
            public GetParentEntity($childEntityId: number):UnityGameFramework.Runtime.Entity;
            
            public GetParentEntity($childEntity: UnityGameFramework.Runtime.Entity):UnityGameFramework.Runtime.Entity;
            
            public GetChildEntityCount($parentEntityId: number):number;
            
            public GetChildEntity($parentEntityId: number):UnityGameFramework.Runtime.Entity;
            
            public GetChildEntity($parentEntity: GameFramework.Entity.IEntity):UnityGameFramework.Runtime.Entity;
            
            public GetChildEntities($parentEntityId: number):System.Array$1<UnityGameFramework.Runtime.Entity>;
            
            public GetChildEntities($parentEntityId: number, $results: System.Collections.Generic.List$1<GameFramework.Entity.IEntity>):void;
            
            public GetChildEntities($parentEntity: UnityGameFramework.Runtime.Entity):System.Array$1<UnityGameFramework.Runtime.Entity>;
            
            public GetChildEntities($parentEntity: GameFramework.Entity.IEntity, $results: System.Collections.Generic.List$1<GameFramework.Entity.IEntity>):void;
            
            public AttachEntity($childEntityId: number, $parentEntityId: number):void;
            
            public AttachEntity($childEntityId: number, $parentEntity: UnityGameFramework.Runtime.Entity):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntityId: number):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntity: UnityGameFramework.Runtime.Entity):void;
            
            public AttachEntity($childEntityId: number, $parentEntityId: number, $parentTransformPath: string):void;
            
            public AttachEntity($childEntityId: number, $parentEntity: UnityGameFramework.Runtime.Entity, $parentTransformPath: string):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntityId: number, $parentTransformPath: string):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntity: UnityGameFramework.Runtime.Entity, $parentTransformPath: string):void;
            
            public AttachEntity($childEntityId: number, $parentEntityId: number, $parentTransform: UnityEngine.Transform):void;
            
            public AttachEntity($childEntityId: number, $parentEntity: UnityGameFramework.Runtime.Entity, $parentTransform: UnityEngine.Transform):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntityId: number, $parentTransform: UnityEngine.Transform):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntity: UnityGameFramework.Runtime.Entity, $parentTransform: UnityEngine.Transform):void;
            
            public AttachEntity($childEntityId: number, $parentEntityId: number, $userData: any):void;
            
            public AttachEntity($childEntityId: number, $parentEntity: UnityGameFramework.Runtime.Entity, $userData: any):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntityId: number, $userData: any):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntity: UnityGameFramework.Runtime.Entity, $userData: any):void;
            
            public AttachEntity($childEntityId: number, $parentEntityId: number, $parentTransformPath: string, $userData: any):void;
            
            public AttachEntity($childEntityId: number, $parentEntity: UnityGameFramework.Runtime.Entity, $parentTransformPath: string, $userData: any):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntityId: number, $parentTransformPath: string, $userData: any):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntity: UnityGameFramework.Runtime.Entity, $parentTransformPath: string, $userData: any):void;
            
            public AttachEntity($childEntityId: number, $parentEntityId: number, $parentTransform: UnityEngine.Transform, $userData: any):void;
            
            public AttachEntity($childEntityId: number, $parentEntity: UnityGameFramework.Runtime.Entity, $parentTransform: UnityEngine.Transform, $userData: any):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntityId: number, $parentTransform: UnityEngine.Transform, $userData: any):void;
            
            public AttachEntity($childEntity: UnityGameFramework.Runtime.Entity, $parentEntity: UnityGameFramework.Runtime.Entity, $parentTransform: UnityEngine.Transform, $userData: any):void;
            
            public DetachEntity($childEntityId: number):void;
            
            public DetachEntity($childEntityId: number, $userData: any):void;
            
            public DetachEntity($childEntity: UnityGameFramework.Runtime.Entity):void;
            
            public DetachEntity($childEntity: UnityGameFramework.Runtime.Entity, $userData: any):void;
            
            public DetachChildEntities($parentEntityId: number):void;
            
            public DetachChildEntities($parentEntityId: number, $userData: any):void;
            
            public DetachChildEntities($parentEntity: UnityGameFramework.Runtime.Entity):void;
            
            public DetachChildEntities($parentEntity: UnityGameFramework.Runtime.Entity, $userData: any):void;
            
            public SetEntityInstanceLocked($entity: UnityGameFramework.Runtime.Entity, $locked: boolean):void;
            
            public SetInstancePriority($entity: UnityGameFramework.Runtime.Entity, $priority: number):void;
            
            public constructor();
            
        }
        
        
        class EventComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get EventHandlerCount(): number;
            
            
            public get EventCount(): number;
            
            
            public Count($id: number):number;
            
            public Check($id: number, $handler: System.EventHandler$1<GameFramework.Event.GameEventArgs>):boolean;
            
            public Subscribe($id: number, $handler: System.EventHandler$1<GameFramework.Event.GameEventArgs>):void;
            
            public Unsubscribe($id: number, $handler: System.EventHandler$1<GameFramework.Event.GameEventArgs>):void;
            
            public SetDefaultHandler($handler: System.EventHandler$1<GameFramework.Event.GameEventArgs>):void;
            
            public Fire($sender: any, $e: GameFramework.Event.GameEventArgs):void;
            
            public FireNow($sender: any, $e: GameFramework.Event.GameEventArgs):void;
            
            public constructor();
            
        }
        
        
        class FileSystemComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
        }
        
        
        class FsmComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
        }
        
        
        class LocalizationComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get Language(): GameFramework.Localization.Language;
            public set Language(value: GameFramework.Localization.Language);
            
            public get SystemLanguage(): GameFramework.Localization.Language;
            
            
            public get DictionaryCount(): number;
            
            
            public get CachedBytesSize(): number;
            
            
            public EnsureCachedBytesSize($ensureSize: number):void;
            
            public FreeCachedBytes():void;
            
            public ReadData($dictionaryAssetName: string):void;
            
            public ReadData($dictionaryAssetName: string, $priority: number):void;
            
            public ReadData($dictionaryAssetName: string, $userData: any):void;
            
            public ReadData($dictionaryAssetName: string, $priority: number, $userData: any):void;
            
            public ParseData($dictionaryString: string):boolean;
            
            public ParseData($dictionaryString: string, $userData: any):boolean;
            
            public ParseData($dictionaryBytes: System.Array$1<number>):boolean;
            
            public ParseData($dictionaryBytes: System.Array$1<number>, $userData: any):boolean;
            
            public ParseData($dictionaryBytes: System.Array$1<number>, $startIndex: number, $length: number):boolean;
            
            public ParseData($dictionaryBytes: System.Array$1<number>, $startIndex: number, $length: number, $userData: any):boolean;
            
            public GetString($key: string):string;
            
            public HasRawString($key: string):boolean;
            
            public GetRawString($key: string):string;
            
            public RemoveRawString($key: string):boolean;
            
            public RemoveAllRawStrings():void;
            
            public constructor();
            
        }
        
        
        class NetworkComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get NetworkChannelCount(): number;
            
            
            public HasNetworkChannel($name: string):boolean;
            
            public GetNetworkChannel($name: string):GameFramework.Network.INetworkChannel;
            
            public GetAllNetworkChannels():System.Array$1<GameFramework.Network.INetworkChannel>;
            
            public GetAllNetworkChannels($results: System.Collections.Generic.List$1<GameFramework.Network.INetworkChannel>):void;
            
            public CreateNetworkChannel($name: string, $serviceType: GameFramework.Network.ServiceType, $networkChannelHelper: GameFramework.Network.INetworkChannelHelper):GameFramework.Network.INetworkChannel;
            
            public DestroyNetworkChannel($name: string):boolean;
            
            public constructor();
            
        }
        
        
        class ObjectPoolComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
        }
        
        
        class ProcedureComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
        }
        
        
        class ResourceComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get ReadOnlyPath(): string;
            
            
            public get ReadWritePath(): string;
            
            
            public get ResourceMode(): GameFramework.Resource.ResourceMode;
            
            
            public get ReadWritePathType(): UnityGameFramework.Runtime.ReadWritePathType;
            
            
            public get CurrentVariant(): string;
            
            
            public get PackageVersionListSerializer(): GameFramework.Resource.PackageVersionListSerializer;
            
            
            public get UpdatableVersionListSerializer(): GameFramework.Resource.UpdatableVersionListSerializer;
            
            
            public get ReadOnlyVersionListSerializer(): GameFramework.Resource.ReadOnlyVersionListSerializer;
            
            
            public get ReadWriteVersionListSerializer(): GameFramework.Resource.ReadWriteVersionListSerializer;
            
            
            public get ResourcePackVersionListSerializer(): GameFramework.Resource.ResourcePackVersionListSerializer;
            
            
            public get LastUnloadUnusedAssetsOperationElapseSeconds(): number;
            
            
            public get MinUnloadUnusedAssetsInterval(): number;
            public set MinUnloadUnusedAssetsInterval(value: number);
            
            public get MaxUnloadUnusedAssetsInterval(): number;
            public set MaxUnloadUnusedAssetsInterval(value: number);
            
            public get ApplicableGameVersion(): string;
            
            
            public get InternalResourceVersion(): number;
            
            
            public get AssetCount(): number;
            
            
            public get ResourceCount(): number;
            
            
            public get ResourceGroupCount(): number;
            
            
            public get UpdatePrefixUri(): string;
            public set UpdatePrefixUri(value: string);
            
            public get GenerateReadWriteVersionListLength(): number;
            public set GenerateReadWriteVersionListLength(value: number);
            
            public get ApplyingResourcePackPath(): string;
            
            
            public get ApplyWaitingCount(): number;
            
            
            public get UpdateRetryCount(): number;
            public set UpdateRetryCount(value: number);
            
            public get UpdatingResourceGroup(): GameFramework.Resource.IResourceGroup;
            
            
            public get UpdateWaitingCount(): number;
            
            
            public get UpdateWaitingWhilePlayingCount(): number;
            
            
            public get UpdateCandidateCount(): number;
            
            
            public get LoadTotalAgentCount(): number;
            
            
            public get LoadFreeAgentCount(): number;
            
            
            public get LoadWorkingAgentCount(): number;
            
            
            public get LoadWaitingTaskCount(): number;
            
            
            public get AssetAutoReleaseInterval(): number;
            public set AssetAutoReleaseInterval(value: number);
            
            public get AssetCapacity(): number;
            public set AssetCapacity(value: number);
            
            public get AssetExpireTime(): number;
            public set AssetExpireTime(value: number);
            
            public get AssetPriority(): number;
            public set AssetPriority(value: number);
            
            public get ResourceAutoReleaseInterval(): number;
            public set ResourceAutoReleaseInterval(value: number);
            
            public get ResourceCapacity(): number;
            public set ResourceCapacity(value: number);
            
            public get ResourceExpireTime(): number;
            public set ResourceExpireTime(value: number);
            
            public get ResourcePriority(): number;
            public set ResourcePriority(value: number);
            
            public SetResourceMode($resourceMode: GameFramework.Resource.ResourceMode):void;
            
            public SetCurrentVariant($currentVariant: string):void;
            
            public SetDecryptResourceCallback($decryptResourceCallback: GameFramework.Resource.DecryptResourceCallback):void;
            
            public UnloadUnusedAssets($performGCCollect: boolean):void;
            
            public ForceUnloadUnusedAssets($performGCCollect: boolean):void;
            
            public InitResources($initResourcesCompleteCallback: GameFramework.Resource.InitResourcesCompleteCallback):void;
            
            public CheckVersionList($latestInternalResourceVersion: number):GameFramework.Resource.CheckVersionListResult;
            
            public UpdateVersionList($versionListLength: number, $versionListHashCode: number, $versionListCompressedLength: number, $versionListCompressedHashCode: number, $updateVersionListCallbacks: GameFramework.Resource.UpdateVersionListCallbacks):void;
            
            public VerifyResources($verifyResourcesCompleteCallback: GameFramework.Resource.VerifyResourcesCompleteCallback):void;
            
            public VerifyResources($verifyResourceLengthPerFrame: number, $verifyResourcesCompleteCallback: GameFramework.Resource.VerifyResourcesCompleteCallback):void;
            
            public CheckResources($checkResourcesCompleteCallback: GameFramework.Resource.CheckResourcesCompleteCallback):void;
            
            public CheckResources($ignoreOtherVariant: boolean, $checkResourcesCompleteCallback: GameFramework.Resource.CheckResourcesCompleteCallback):void;
            
            public ApplyResources($resourcePackPath: string, $applyResourcesCompleteCallback: GameFramework.Resource.ApplyResourcesCompleteCallback):void;
            
            public UpdateResources($updateResourcesCompleteCallback: GameFramework.Resource.UpdateResourcesCompleteCallback):void;
            
            public UpdateResources($resourceGroupName: string, $updateResourcesCompleteCallback: GameFramework.Resource.UpdateResourcesCompleteCallback):void;
            
            public StopUpdateResources():void;
            
            public VerifyResourcePack($resourcePackPath: string):boolean;
            
            public GetAllLoadAssetInfos():System.Array$1<GameFramework.TaskInfo>;
            
            public GetAllLoadAssetInfos($results: System.Collections.Generic.List$1<GameFramework.TaskInfo>):void;
            
            public HasAsset($assetName: string):GameFramework.Resource.HasAssetResult;
            
            public LoadAsset($assetName: string, $loadAssetCallbacks: GameFramework.Resource.LoadAssetCallbacks):void;
            
            public LoadAsset($assetName: string, $assetType: System.Type, $loadAssetCallbacks: GameFramework.Resource.LoadAssetCallbacks):void;
            
            public LoadAsset($assetName: string, $priority: number, $loadAssetCallbacks: GameFramework.Resource.LoadAssetCallbacks):void;
            
            public LoadAsset($assetName: string, $loadAssetCallbacks: GameFramework.Resource.LoadAssetCallbacks, $userData: any):void;
            
            public LoadAsset($assetName: string, $assetType: System.Type, $priority: number, $loadAssetCallbacks: GameFramework.Resource.LoadAssetCallbacks):void;
            
            public LoadAsset($assetName: string, $assetType: System.Type, $loadAssetCallbacks: GameFramework.Resource.LoadAssetCallbacks, $userData: any):void;
            
            public LoadAsset($assetName: string, $priority: number, $loadAssetCallbacks: GameFramework.Resource.LoadAssetCallbacks, $userData: any):void;
            
            public LoadAsset($assetName: string, $assetType: System.Type, $priority: number, $loadAssetCallbacks: GameFramework.Resource.LoadAssetCallbacks, $userData: any):void;
            
            public UnloadAsset($asset: any):void;
            
            public GetBinaryPath($binaryAssetName: string):string;
            
            public GetBinaryPath($binaryAssetName: string, $storageInReadOnly: $Ref<boolean>, $storageInFileSystem: $Ref<boolean>, $relativePath: $Ref<string>, $fileName: $Ref<string>):boolean;
            
            public GetBinaryLength($binaryAssetName: string):number;
            
            public LoadBinary($binaryAssetName: string, $loadBinaryCallbacks: GameFramework.Resource.LoadBinaryCallbacks):void;
            
            public LoadBinary($binaryAssetName: string, $loadBinaryCallbacks: GameFramework.Resource.LoadBinaryCallbacks, $userData: any):void;
            
            public LoadBinaryFromFileSystem($binaryAssetName: string):System.Array$1<number>;
            
            public LoadBinaryFromFileSystem($binaryAssetName: string, $buffer: System.Array$1<number>):number;
            
            public LoadBinaryFromFileSystem($binaryAssetName: string, $buffer: System.Array$1<number>, $startIndex: number):number;
            
            public LoadBinaryFromFileSystem($binaryAssetName: string, $buffer: System.Array$1<number>, $startIndex: number, $length: number):number;
            
            public LoadBinarySegmentFromFileSystem($binaryAssetName: string, $length: number):System.Array$1<number>;
            
            public LoadBinarySegmentFromFileSystem($binaryAssetName: string, $offset: number, $length: number):System.Array$1<number>;
            
            public LoadBinarySegmentFromFileSystem($binaryAssetName: string, $buffer: System.Array$1<number>):number;
            
            public LoadBinarySegmentFromFileSystem($binaryAssetName: string, $buffer: System.Array$1<number>, $length: number):number;
            
            public LoadBinarySegmentFromFileSystem($binaryAssetName: string, $buffer: System.Array$1<number>, $startIndex: number, $length: number):number;
            
            public LoadBinarySegmentFromFileSystem($binaryAssetName: string, $offset: number, $buffer: System.Array$1<number>):number;
            
            public LoadBinarySegmentFromFileSystem($binaryAssetName: string, $offset: number, $buffer: System.Array$1<number>, $length: number):number;
            
            public LoadBinarySegmentFromFileSystem($binaryAssetName: string, $offset: number, $buffer: System.Array$1<number>, $startIndex: number, $length: number):number;
            
            public HasResourceGroup($resourceGroupName: string):boolean;
            
            public GetResourceGroup():GameFramework.Resource.IResourceGroup;
            
            public GetResourceGroup($resourceGroupName: string):GameFramework.Resource.IResourceGroup;
            
            public GetAllResourceGroups():System.Array$1<GameFramework.Resource.IResourceGroup>;
            
            public GetAllResourceGroups($results: System.Collections.Generic.List$1<GameFramework.Resource.IResourceGroup>):void;
            
            public GetResourceGroupCollection(...resourceGroupNames: string[]):GameFramework.Resource.IResourceGroupCollection;
            
            public GetResourceGroupCollection($resourceGroupNames: System.Collections.Generic.List$1<string>):GameFramework.Resource.IResourceGroupCollection;
            
            public constructor();
            
        }
        
        
        class SceneComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get MainCamera(): UnityEngine.Camera;
            
            
            public static GetSceneName($sceneAssetName: string):string;
            
            public SceneIsLoaded($sceneAssetName: string):boolean;
            
            public GetLoadedSceneAssetNames():System.Array$1<string>;
            
            public GetLoadedSceneAssetNames($results: System.Collections.Generic.List$1<string>):void;
            
            public SceneIsLoading($sceneAssetName: string):boolean;
            
            public GetLoadingSceneAssetNames():System.Array$1<string>;
            
            public GetLoadingSceneAssetNames($results: System.Collections.Generic.List$1<string>):void;
            
            public SceneIsUnloading($sceneAssetName: string):boolean;
            
            public GetUnloadingSceneAssetNames():System.Array$1<string>;
            
            public GetUnloadingSceneAssetNames($results: System.Collections.Generic.List$1<string>):void;
            
            public HasScene($sceneAssetName: string):boolean;
            
            public LoadScene($sceneAssetName: string):void;
            
            public LoadScene($sceneAssetName: string, $priority: number):void;
            
            public LoadScene($sceneAssetName: string, $userData: any):void;
            
            public LoadScene($sceneAssetName: string, $priority: number, $userData: any):void;
            
            public UnloadScene($sceneAssetName: string):void;
            
            public UnloadScene($sceneAssetName: string, $userData: any):void;
            
            public SetSceneOrder($sceneAssetName: string, $sceneOrder: number):void;
            
            public RefreshMainCamera():void;
            
            public constructor();
            
        }
        
        
        class SettingComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get Count(): number;
            
            
            public Save():void;
            
            public GetAllSettingNames():System.Array$1<string>;
            
            public GetAllSettingNames($results: System.Collections.Generic.List$1<string>):void;
            
            public HasSetting($settingName: string):boolean;
            
            public RemoveSetting($settingName: string):void;
            
            public RemoveAllSettings():void;
            
            public GetBool($settingName: string):boolean;
            
            public GetBool($settingName: string, $defaultValue: boolean):boolean;
            
            public SetBool($settingName: string, $value: boolean):void;
            
            public GetInt($settingName: string):number;
            
            public GetInt($settingName: string, $defaultValue: number):number;
            
            public SetInt($settingName: string, $value: number):void;
            
            public GetFloat($settingName: string):number;
            
            public GetFloat($settingName: string, $defaultValue: number):number;
            
            public SetFloat($settingName: string, $value: number):void;
            
            public GetString($settingName: string):string;
            
            public GetString($settingName: string, $defaultValue: string):string;
            
            public SetString($settingName: string, $value: string):void;
            
            public GetObject($objectType: System.Type, $settingName: string):any;
            
            public GetObject($objectType: System.Type, $settingName: string, $defaultObj: any):any;
            
            public SetObject($settingName: string, $obj: any):void;
            
            public constructor();
            
        }
        
        
        class SoundComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get SoundGroupCount(): number;
            
            
            public get AudioMixer(): UnityEngine.Audio.AudioMixer;
            
            
            public HasSoundGroup($soundGroupName: string):boolean;
            
            public GetSoundGroup($soundGroupName: string):GameFramework.Sound.ISoundGroup;
            
            public GetAllSoundGroups():System.Array$1<GameFramework.Sound.ISoundGroup>;
            
            public GetAllSoundGroups($results: System.Collections.Generic.List$1<GameFramework.Sound.ISoundGroup>):void;
            
            public AddSoundGroup($soundGroupName: string, $soundAgentHelperCount: number):boolean;
            
            public AddSoundGroup($soundGroupName: string, $soundGroupAvoidBeingReplacedBySamePriority: boolean, $soundGroupMute: boolean, $soundGroupVolume: number, $soundAgentHelperCount: number):boolean;
            
            public GetAllLoadingSoundSerialIds():System.Array$1<number>;
            
            public GetAllLoadingSoundSerialIds($results: System.Collections.Generic.List$1<number>):void;
            
            public IsLoadingSound($serialId: number):boolean;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string):number;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string, $priority: number):number;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string, $playSoundParams: GameFramework.Sound.PlaySoundParams):number;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string, $bindingEntity: UnityGameFramework.Runtime.Entity):number;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string, $worldPosition: UnityEngine.Vector3):number;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string, $userData: any):number;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string, $priority: number, $playSoundParams: GameFramework.Sound.PlaySoundParams):number;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string, $priority: number, $playSoundParams: GameFramework.Sound.PlaySoundParams, $userData: any):number;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string, $priority: number, $playSoundParams: GameFramework.Sound.PlaySoundParams, $bindingEntity: UnityGameFramework.Runtime.Entity):number;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string, $priority: number, $playSoundParams: GameFramework.Sound.PlaySoundParams, $bindingEntity: UnityGameFramework.Runtime.Entity, $userData: any):number;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string, $priority: number, $playSoundParams: GameFramework.Sound.PlaySoundParams, $worldPosition: UnityEngine.Vector3):number;
            
            public PlaySound($soundAssetName: string, $soundGroupName: string, $priority: number, $playSoundParams: GameFramework.Sound.PlaySoundParams, $worldPosition: UnityEngine.Vector3, $userData: any):number;
            
            public StopSound($serialId: number):boolean;
            
            public StopSound($serialId: number, $fadeOutSeconds: number):boolean;
            
            public StopAllLoadedSounds():void;
            
            public StopAllLoadedSounds($fadeOutSeconds: number):void;
            
            public StopAllLoadingSounds():void;
            
            public PauseSound($serialId: number):void;
            
            public PauseSound($serialId: number, $fadeOutSeconds: number):void;
            
            public ResumeSound($serialId: number):void;
            
            public ResumeSound($serialId: number, $fadeInSeconds: number):void;
            
            public constructor();
            
        }
        
        
        class UIComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get UIGroupCount(): number;
            
            
            public get InstanceAutoReleaseInterval(): number;
            public set InstanceAutoReleaseInterval(value: number);
            
            public get InstanceCapacity(): number;
            public set InstanceCapacity(value: number);
            
            public get InstanceExpireTime(): number;
            public set InstanceExpireTime(value: number);
            
            public get InstancePriority(): number;
            public set InstancePriority(value: number);
            
            public HasUIGroup($uiGroupName: string):boolean;
            
            public GetUIGroup($uiGroupName: string):GameFramework.UI.IUIGroup;
            
            public GetAllUIGroups():System.Array$1<GameFramework.UI.IUIGroup>;
            
            public GetAllUIGroups($results: System.Collections.Generic.List$1<GameFramework.UI.IUIGroup>):void;
            
            public AddUIGroup($uiGroupName: string):boolean;
            
            public AddUIGroup($uiGroupName: string, $depth: number):boolean;
            
            public HasUIForm($serialId: number):boolean;
            
            public HasUIForm($uiFormAssetName: string):boolean;
            
            public GetUIForm($serialId: number):UnityGameFramework.Runtime.UIForm;
            
            public GetUIForm($uiFormAssetName: string):UnityGameFramework.Runtime.UIForm;
            
            public GetUIForms($uiFormAssetName: string):System.Array$1<UnityGameFramework.Runtime.UIForm>;
            
            public GetUIForms($uiFormAssetName: string, $results: System.Collections.Generic.List$1<UnityGameFramework.Runtime.UIForm>):void;
            
            public GetAllLoadedUIForms():System.Array$1<UnityGameFramework.Runtime.UIForm>;
            
            public GetAllLoadedUIForms($results: System.Collections.Generic.List$1<UnityGameFramework.Runtime.UIForm>):void;
            
            public GetAllLoadingUIFormSerialIds():System.Array$1<number>;
            
            public GetAllLoadingUIFormSerialIds($results: System.Collections.Generic.List$1<number>):void;
            
            public IsLoadingUIForm($serialId: number):boolean;
            
            public IsLoadingUIForm($uiFormAssetName: string):boolean;
            
            public IsValidUIForm($uiForm: UnityGameFramework.Runtime.UIForm):boolean;
            
            public OpenUIForm($uiFormAssetName: string, $uiGroupName: string):number;
            
            public OpenUIForm($uiFormAssetName: string, $uiGroupName: string, $priority: number):number;
            
            public OpenUIForm($uiFormAssetName: string, $uiGroupName: string, $pauseCoveredUIForm: boolean):number;
            
            public OpenUIForm($uiFormAssetName: string, $uiGroupName: string, $userData: any):number;
            
            public OpenUIForm($uiFormAssetName: string, $uiGroupName: string, $priority: number, $pauseCoveredUIForm: boolean):number;
            
            public OpenUIForm($uiFormAssetName: string, $uiGroupName: string, $priority: number, $userData: any):number;
            
            public OpenUIForm($uiFormAssetName: string, $uiGroupName: string, $pauseCoveredUIForm: boolean, $userData: any):number;
            
            public OpenUIForm($uiFormAssetName: string, $uiGroupName: string, $priority: number, $pauseCoveredUIForm: boolean, $userData: any):number;
            
            public CloseUIForm($serialId: number):void;
            
            public CloseUIForm($serialId: number, $userData: any):void;
            
            public CloseUIForm($uiForm: UnityGameFramework.Runtime.UIForm):void;
            
            public CloseUIForm($uiForm: UnityGameFramework.Runtime.UIForm, $userData: any):void;
            
            public CloseAllLoadedUIForms():void;
            
            public CloseAllLoadedUIForms($userData: any):void;
            
            public CloseAllLoadingUIForms():void;
            
            public RefocusUIForm($uiForm: UnityGameFramework.Runtime.UIForm):void;
            
            public RefocusUIForm($uiForm: UnityGameFramework.Runtime.UIForm, $userData: any):void;
            
            public SetUIFormInstanceLocked($uiForm: UnityGameFramework.Runtime.UIForm, $locked: boolean):void;
            
            public SetUIFormInstancePriority($uiForm: UnityGameFramework.Runtime.UIForm, $priority: number):void;
            
            public constructor();
            
        }
        
        
        class WebRequestComponent extends UnityGameFramework.Runtime.GameFrameworkComponent{ 
            
            public get TotalAgentCount(): number;
            
            
            public get FreeAgentCount(): number;
            
            
            public get WorkingAgentCount(): number;
            
            
            public get WaitingTaskCount(): number;
            
            
            public get Timeout(): number;
            public set Timeout(value: number);
            
            public GetWebRequestInfo($serialId: number):GameFramework.TaskInfo;
            
            public GetWebRequestInfos($tag: string):System.Array$1<GameFramework.TaskInfo>;
            
            public GetAllWebRequestInfos($tag: string, $results: System.Collections.Generic.List$1<GameFramework.TaskInfo>):void;
            
            public GetAllWebRequestInfos():System.Array$1<GameFramework.TaskInfo>;
            
            public GetAllWebRequestInfos($results: System.Collections.Generic.List$1<GameFramework.TaskInfo>):void;
            
            public AddWebRequest($webRequestUri: string):number;
            
            public AddWebRequest($webRequestUri: string, $postData: System.Array$1<number>):number;
            
            public AddWebRequest($webRequestUri: string, $wwwForm: UnityEngine.WWWForm):number;
            
            public AddWebRequest($webRequestUri: string, $tag: string):number;
            
            public AddWebRequest($webRequestUri: string, $priority: number):number;
            
            public AddWebRequest($webRequestUri: string, $userData: any):number;
            
            public AddWebRequest($webRequestUri: string, $postData: System.Array$1<number>, $tag: string):number;
            
            public AddWebRequest($webRequestUri: string, $wwwForm: UnityEngine.WWWForm, $tag: string):number;
            
            public AddWebRequest($webRequestUri: string, $postData: System.Array$1<number>, $priority: number):number;
            
            public AddWebRequest($webRequestUri: string, $wwwForm: UnityEngine.WWWForm, $priority: number):number;
            
            public AddWebRequest($webRequestUri: string, $postData: System.Array$1<number>, $userData: any):number;
            
            public AddWebRequest($webRequestUri: string, $wwwForm: UnityEngine.WWWForm, $userData: any):number;
            
            public AddWebRequest($webRequestUri: string, $tag: string, $priority: number):number;
            
            public AddWebRequest($webRequestUri: string, $tag: string, $userData: any):number;
            
            public AddWebRequest($webRequestUri: string, $priority: number, $userData: any):number;
            
            public AddWebRequest($webRequestUri: string, $postData: System.Array$1<number>, $tag: string, $priority: number):number;
            
            public AddWebRequest($webRequestUri: string, $wwwForm: UnityEngine.WWWForm, $tag: string, $priority: number):number;
            
            public AddWebRequest($webRequestUri: string, $postData: System.Array$1<number>, $tag: string, $userData: any):number;
            
            public AddWebRequest($webRequestUri: string, $wwwForm: UnityEngine.WWWForm, $tag: string, $userData: any):number;
            
            public AddWebRequest($webRequestUri: string, $postData: System.Array$1<number>, $priority: number, $userData: any):number;
            
            public AddWebRequest($webRequestUri: string, $wwwForm: UnityEngine.WWWForm, $priority: number, $userData: any):number;
            
            public AddWebRequest($webRequestUri: string, $tag: string, $priority: number, $userData: any):number;
            
            public AddWebRequest($webRequestUri: string, $postData: System.Array$1<number>, $tag: string, $priority: number, $userData: any):number;
            
            public AddWebRequest($webRequestUri: string, $wwwForm: UnityEngine.WWWForm, $tag: string, $priority: number, $userData: any):number;
            
            public RemoveWebRequest($serialId: number):boolean;
            
            public RemoveWebRequests($tag: string):number;
            
            public RemoveAllWebRequests():number;
            
            public constructor();
            
        }
        
        
        class DownloadStartEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get SerialId(): number;
            
            
            public get DownloadPath(): string;
            
            
            public get DownloadUri(): string;
            
            
            public get CurrentLength(): bigint;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.Download.DownloadStartEventArgs):UnityGameFramework.Runtime.DownloadStartEventArgs;
            
            public constructor();
            
        }
        
        
        class DownloadSuccessEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get SerialId(): number;
            
            
            public get DownloadPath(): string;
            
            
            public get DownloadUri(): string;
            
            
            public get CurrentLength(): bigint;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.Download.DownloadSuccessEventArgs):UnityGameFramework.Runtime.DownloadSuccessEventArgs;
            
            public constructor();
            
        }
        
        
        class DownloadFailureEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get SerialId(): number;
            
            
            public get DownloadPath(): string;
            
            
            public get DownloadUri(): string;
            
            
            public get ErrorMessage(): string;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.Download.DownloadFailureEventArgs):UnityGameFramework.Runtime.DownloadFailureEventArgs;
            
            public constructor();
            
        }
        
        
        class Entity extends UnityEngine.MonoBehaviour implements GameFramework.Entity.IEntity{ 
            
            public get Id(): number;
            
            
            public get EntityAssetName(): string;
            
            
            public get Handle(): any;
            
            
            public get EntityGroup(): GameFramework.Entity.IEntityGroup;
            
            
            public get Logic(): UnityGameFramework.Runtime.EntityLogic;
            
            
            public OnInit($entityId: number, $entityAssetName: string, $entityGroup: GameFramework.Entity.IEntityGroup, $isNewInstance: boolean, $userData: any):void;
            
            public OnRecycle():void;
            
            public OnShow($userData: any):void;
            
            public OnHide($isShutdown: boolean, $userData: any):void;
            
            public OnAttached($childEntity: GameFramework.Entity.IEntity, $userData: any):void;
            
            public OnDetached($childEntity: GameFramework.Entity.IEntity, $userData: any):void;
            
            public OnAttachTo($parentEntity: GameFramework.Entity.IEntity, $userData: any):void;
            
            public OnDetachFrom($parentEntity: GameFramework.Entity.IEntity, $userData: any):void;
            
            public OnUpdate($elapseSeconds: number, $realElapseSeconds: number):void;
            
            public constructor();
            
        }
        
        
        class EntityLogic extends UnityEngine.MonoBehaviour{ 
            
        }
        
        
        class ShowEntitySuccessEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get EntityLogicType(): System.Type;
            
            
            public get Entity(): UnityGameFramework.Runtime.Entity;
            
            
            public get Duration(): number;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.Entity.ShowEntitySuccessEventArgs):UnityGameFramework.Runtime.ShowEntitySuccessEventArgs;
            
            public constructor();
            
        }
        
        
        class ShowEntityFailureEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get EntityId(): number;
            
            
            public get EntityLogicType(): System.Type;
            
            
            public get EntityAssetName(): string;
            
            
            public get EntityGroupName(): string;
            
            
            public get ErrorMessage(): string;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.Entity.ShowEntityFailureEventArgs):UnityGameFramework.Runtime.ShowEntityFailureEventArgs;
            
            public constructor();
            
        }
        
        
        class HideEntityCompleteEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get EntityId(): number;
            
            
            public get EntityAssetName(): string;
            
            
            public get EntityGroup(): GameFramework.Entity.IEntityGroup;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.Entity.HideEntityCompleteEventArgs):UnityGameFramework.Runtime.HideEntityCompleteEventArgs;
            
            public constructor();
            
        }
        
        
        enum ReadWritePathType{ Unspecified = 0, TemporaryCache = 1, PersistentData = 2 }
        
        
        class PlaySoundSuccessEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get SerialId(): number;
            
            
            public get SoundAssetName(): string;
            
            
            public get SoundAgent(): GameFramework.Sound.ISoundAgent;
            
            
            public get Duration(): number;
            
            
            public get BindingEntity(): UnityGameFramework.Runtime.Entity;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.Sound.PlaySoundSuccessEventArgs):UnityGameFramework.Runtime.PlaySoundSuccessEventArgs;
            
            public constructor();
            
        }
        
        
        class PlaySoundFailureEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get SerialId(): number;
            
            
            public get SoundAssetName(): string;
            
            
            public get SoundGroupName(): string;
            
            
            public get PlaySoundParams(): GameFramework.Sound.PlaySoundParams;
            
            
            public get BindingEntity(): UnityGameFramework.Runtime.Entity;
            
            
            public get ErrorCode(): GameFramework.Sound.PlaySoundErrorCode;
            
            
            public get ErrorMessage(): string;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.Sound.PlaySoundFailureEventArgs):UnityGameFramework.Runtime.PlaySoundFailureEventArgs;
            
            public constructor();
            
        }
        
        
        class UIForm extends UnityEngine.MonoBehaviour implements GameFramework.UI.IUIForm{ 
            
            public get SerialId(): number;
            
            
            public get UIFormAssetName(): string;
            
            
            public get Handle(): any;
            
            
            public get UIGroup(): GameFramework.UI.IUIGroup;
            
            
            public get DepthInUIGroup(): number;
            
            
            public get PauseCoveredUIForm(): boolean;
            
            
            public get Logic(): UnityGameFramework.Runtime.UIFormLogic;
            
            
            public OnInit($serialId: number, $uiFormAssetName: string, $uiGroup: GameFramework.UI.IUIGroup, $pauseCoveredUIForm: boolean, $isNewInstance: boolean, $userData: any):void;
            
            public OnRecycle():void;
            
            public OnOpen($userData: any):void;
            
            public OnClose($isShutdown: boolean, $userData: any):void;
            
            public OnPause():void;
            
            public OnResume():void;
            
            public OnCover():void;
            
            public OnReveal():void;
            
            public OnRefocus($userData: any):void;
            
            public OnUpdate($elapseSeconds: number, $realElapseSeconds: number):void;
            
            public OnDepthChanged($uiGroupDepth: number, $depthInUIGroup: number):void;
            
            public constructor();
            
        }
        
        
        class UIFormLogic extends UnityEngine.MonoBehaviour{ 
            
        }
        
        
        class OpenUIFormSuccessEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get UIForm(): UnityGameFramework.Runtime.UIForm;
            
            
            public get Duration(): number;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.UI.OpenUIFormSuccessEventArgs):UnityGameFramework.Runtime.OpenUIFormSuccessEventArgs;
            
            public constructor();
            
        }
        
        
        class OpenUIFormFailureEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get SerialId(): number;
            
            
            public get UIFormAssetName(): string;
            
            
            public get UIGroupName(): string;
            
            
            public get PauseCoveredUIForm(): boolean;
            
            
            public get ErrorMessage(): string;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.UI.OpenUIFormFailureEventArgs):UnityGameFramework.Runtime.OpenUIFormFailureEventArgs;
            
            public constructor();
            
        }
        
        
        class CloseUIFormCompleteEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get SerialId(): number;
            
            
            public get UIFormAssetName(): string;
            
            
            public get UIGroup(): GameFramework.UI.IUIGroup;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.UI.CloseUIFormCompleteEventArgs):UnityGameFramework.Runtime.CloseUIFormCompleteEventArgs;
            
            public constructor();
            
        }
        
        
        class WebRequestStartEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get SerialId(): number;
            
            
            public get WebRequestUri(): string;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.WebRequest.WebRequestStartEventArgs):UnityGameFramework.Runtime.WebRequestStartEventArgs;
            
            public constructor();
            
        }
        
        
        class WebRequestSuccessEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get SerialId(): number;
            
            
            public get WebRequestUri(): string;
            
            
            public get UserData(): any;
            
            
            public GetWebResponseBytes():System.Array$1<number>;
            
            public static Create($e: GameFramework.WebRequest.WebRequestSuccessEventArgs):UnityGameFramework.Runtime.WebRequestSuccessEventArgs;
            
            public constructor();
            
        }
        
        
        class WebRequestFailureEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get SerialId(): number;
            
            
            public get WebRequestUri(): string;
            
            
            public get ErrorMessage(): string;
            
            
            public get UserData(): any;
            
            
            public static Create($e: GameFramework.WebRequest.WebRequestFailureEventArgs):UnityGameFramework.Runtime.WebRequestFailureEventArgs;
            
            public constructor();
            
        }
        
        
    }
    namespace UnityGameFramework.Runtime.Extension {
        
        class Entry extends UnityEngine.MonoBehaviour{ 
            
            public static get Base(): UnityGameFramework.Runtime.BaseComponent;
            
            
            public static get Config(): UnityGameFramework.Runtime.ConfigComponent;
            
            
            public static get DataNode(): UnityGameFramework.Runtime.DataNodeComponent;
            
            
            public static get DataTable(): UnityGameFramework.Runtime.DataTableComponent;
            
            
            public static get Debugger(): UnityGameFramework.Runtime.DebuggerComponent;
            
            
            public static get Download(): UnityGameFramework.Runtime.DownloadComponent;
            
            
            public static get Entity(): UnityGameFramework.Runtime.EntityComponent;
            
            
            public static get Event(): UnityGameFramework.Runtime.EventComponent;
            
            
            public static get FileSystem(): UnityGameFramework.Runtime.FileSystemComponent;
            
            
            public static get Fsm(): UnityGameFramework.Runtime.FsmComponent;
            
            
            public static get Localization(): UnityGameFramework.Runtime.LocalizationComponent;
            
            
            public static get Network(): UnityGameFramework.Runtime.NetworkComponent;
            
            
            public static get ObjectPool(): UnityGameFramework.Runtime.ObjectPoolComponent;
            
            
            public static get Procedure(): UnityGameFramework.Runtime.ProcedureComponent;
            
            
            public static get Resource(): UnityGameFramework.Runtime.ResourceComponent;
            
            
            public static get Scene(): UnityGameFramework.Runtime.SceneComponent;
            
            
            public static get Setting(): UnityGameFramework.Runtime.SettingComponent;
            
            
            public static get Sound(): UnityGameFramework.Runtime.SoundComponent;
            
            
            public static get UI(): UnityGameFramework.Runtime.UIComponent;
            
            
            public static get WebRequest(): UnityGameFramework.Runtime.WebRequestComponent;
            
            
            public static get PlayerData(): UnityGameFramework.Runtime.Extension.PlayerDataComponent;
            
            
            public static get Camera(): UnityGameFramework.Runtime.Extension.CameraComponent;
            
            
            public static get Script(): UnityGameFramework.Runtime.Extension.ScriptComponent;
            
            
            public static get Video(): UnityGameFramework.Runtime.Extension.VideoComponent;
            
            
            public static get BuiltinData(): UnityGameFramework.Runtime.Extension.BuiltinDataComponent;
            
            
            public static get MVC(): UnityGameFramework.Runtime.Extension.MVCComponent;
            
            
            public static get R(): UnityGameFramework.Runtime.Extension.RComponent;
            
            
            public static get GM(): UnityGameFramework.Runtime.Extension.GMComponent;
            
            
            public static get Time(): UnityGameFramework.Runtime.Extension.TimeComponent;
            
            
            public constructor();
            
        }
        
        
        class PlayerDataComponent extends UnityGameFramework.Runtime.Extension.CustomGameFrameworkComponent{ 
            
        }
        
        
        class CustomGameFrameworkComponent extends UnityEngine.MonoBehaviour{ 
            
        }
        
        
        class CameraComponent extends UnityGameFramework.Runtime.Extension.CustomGameFrameworkComponent{ 
            
            public get CanvasScale(): number;
            
            
            public get MainCamera(): UnityEngine.Camera;
            
            
            public get UI2DCamera(): UnityEngine.Camera;
            
            
            public get UI3DCamera(): UnityEngine.Camera;
            
            
            public WorldPositionToUIPosition($worldPosition: UnityEngine.Vector3, $uiPosition: $Ref<UnityEngine.Vector3>):void;
            
            public ShowRenderTexture($rawImage: UnityEngine.UI.RawImage):void;
            
            public HideRenderTexture():void;
            
            public constructor();
            
        }
        
        
        class ScriptComponent extends UnityGameFramework.Runtime.Extension.CustomGameFrameworkComponent{ 
            
            public StartupCallback: System.Action;
            
            public UpdateCallback: System.Action;
            
            public ShutdownCallback: System.Action;
            
            public TurnOn():void;
            
            public TurnOff():void;
            
            public constructor();
            
        }
        
        
        class VideoComponent extends UnityGameFramework.Runtime.Extension.CustomGameFrameworkComponent{ 
            
        }
        
        
        class BuiltinDataComponent extends UnityGameFramework.Runtime.Extension.CustomGameFrameworkComponent{ 
            
            public get SplashForm(): UnityGameFramework.Runtime.Extension.SplashForm;
            
            
            public get UpdateResourceForm(): UnityGameFramework.Runtime.Extension.UpdateResourceForm;
            
            
            public get DialogForm(): UnityGameFramework.Runtime.Extension.DialogForm;
            
            
            public get BuildInfo(): UnityGameFramework.Runtime.Extension.BuildInfo;
            
            
            public InitBuildInfo():void;
            
            public InitDefaultDictionary():void;
            
            public constructor();
            
        }
        
        
        class MVCComponent extends UnityGameFramework.Runtime.Extension.CustomGameFrameworkComponent{ 
            
        }
        
        
        class RComponent extends UnityGameFramework.Runtime.Extension.CustomGameFrameworkComponent{ 
            
        }
        
        
        class GMComponent extends UnityGameFramework.Runtime.Extension.CustomGameFrameworkComponent{ 
            
        }
        
        
        class TimeComponent extends UnityGameFramework.Runtime.Extension.CustomGameFrameworkComponent{ 
            
            public get EnableFakeTime(): boolean;
            
            
            public get LocalTime(): boolean;
            
            
            public get FakeTime(): string;
            
            
            public get Now(): Date;
            
            
            public get FrameCount(): number;
            
            
            public get TimeScale(): number;
            
            
            public get DeltaTime(): number;
            
            
            public get UnscaledDeltaTime(): number;
            
            
            public get Time(): number;
            
            
            public get UnscaledTime(): number;
            
            
            public get RealtimeSinceStartup(): number;
            
            
            public constructor();
            
        }
        
        
        class Entity extends UnityGameFramework.Runtime.EntityLogic{ 
            
            public OnDeinit():void;
            
            public constructor();
            
        }
        
        
        class EntityAttachedEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get EntityHash(): number;
            
            
            public get EntityId(): number;
            
            
            public get ChildEntity(): UnityGameFramework.Runtime.EntityLogic;
            
            
            public get ParentTransform(): UnityEngine.Transform;
            
            
            public get UserData(): any;
            
            
            public static Create($entityHash: number, $entityId: number, $childEntity: UnityGameFramework.Runtime.EntityLogic, $parentTransform: UnityEngine.Transform, $userData: any):UnityGameFramework.Runtime.Extension.EntityAttachedEventArgs;
            
            public constructor();
            
        }
        
        
        class EntityAttachToEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get EntityHash(): number;
            
            
            public get EntityId(): number;
            
            
            public get ParentEntity(): UnityGameFramework.Runtime.EntityLogic;
            
            
            public get ParentTransform(): UnityEngine.Transform;
            
            
            public get UserData(): any;
            
            
            public static Create($entityHash: number, $entityId: number, $parentEntity: UnityGameFramework.Runtime.EntityLogic, $parentTransform: UnityEngine.Transform, $userData: any):UnityGameFramework.Runtime.Extension.EntityAttachToEventArgs;
            
            public constructor();
            
        }
        
        
        class EntityDeinitEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get EntityHash(): number;
            
            
            public get EntityId(): number;
            
            
            public get Entity(): UnityGameFramework.Runtime.EntityLogic;
            
            
            public get EntityGO(): UnityEngine.GameObject;
            
            
            public static Create($entityHash: number, $entityId: number, $entity: UnityGameFramework.Runtime.EntityLogic, $entityGO: UnityEngine.GameObject):UnityGameFramework.Runtime.Extension.EntityDeinitEventArgs;
            
            public constructor();
            
        }
        
        
        class EntityDetachedEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get EntityHash(): number;
            
            
            public get EntityId(): number;
            
            
            public get ChildEntity(): UnityGameFramework.Runtime.EntityLogic;
            
            
            public get UserData(): any;
            
            
            public static Create($entityHash: number, $entityId: number, $childEntity: UnityGameFramework.Runtime.EntityLogic, $userData: any):UnityGameFramework.Runtime.Extension.EntityDetachedEventArgs;
            
            public constructor();
            
        }
        
        
        class EntityHideEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get EntityId(): number;
            
            
            public get EntityHash(): number;
            
            
            public get IsShutdown(): boolean;
            
            
            public get UserData(): any;
            
            
            public static Create($entityHash: number, $entityId: number, $isShutdown: boolean, $userData: any):UnityGameFramework.Runtime.Extension.EntityHideEventArgs;
            
            public constructor();
            
        }
        
        
        class EntityInitEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get EntityHash(): number;
            
            
            public get EntityId(): number;
            
            
            public get EntityTypeId(): number;
            
            
            public get Entity(): UnityGameFramework.Runtime.EntityLogic;
            
            
            public get EntityGO(): UnityEngine.GameObject;
            
            
            public get UserData(): any;
            
            
            public static Create($entityHash: number, $entityId: number, $entityType: number, $entity: UnityGameFramework.Runtime.EntityLogic, $entityGO: UnityEngine.GameObject, $userData: any):UnityGameFramework.Runtime.Extension.EntityInitEventArgs;
            
            public constructor();
            
        }
        
        
        class EntityRecycleEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get EntityHash(): number;
            
            
            public get EntityId(): number;
            
            
            public static Create($entityHash: number, $entityId: number):UnityGameFramework.Runtime.Extension.EntityRecycleEventArgs;
            
            public constructor();
            
        }
        
        
        class EntityShowEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get EntityHash(): number;
            
            
            public get EntityId(): number;
            
            
            public get Entity(): UnityGameFramework.Runtime.EntityLogic;
            
            
            public get EntityGO(): UnityEngine.GameObject;
            
            
            public get UserData(): any;
            
            
            public static Create($entityHash: number, $entityId: number, $entity: UnityGameFramework.Runtime.EntityLogic, $entityGO: UnityEngine.GameObject, $userData: any):UnityGameFramework.Runtime.Extension.EntityShowEventArgs;
            
            public constructor();
            
        }
        
        
        class UIForm extends UnityGameFramework.Runtime.UIFormLogic{ 
            
            public OnDeinit():void;
            
            public constructor();
            
        }
        
        
        class UIFormCloseEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get FormHash(): number;
            
            
            public get FormId(): number;
            
            
            public get IsShutdown(): boolean;
            
            
            public get UserData(): any;
            
            
            public static Create($formHash: number, $formId: number, $isShutdown: boolean, $userData: any):UnityGameFramework.Runtime.Extension.UIFormCloseEventArgs;
            
            public constructor();
            
        }
        
        
        class UIFormCoverEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get FormHash(): number;
            
            
            public get FormId(): number;
            
            
            public get UserData(): any;
            
            
            public static Create($formHash: number, $formId: number, $userData: any):UnityGameFramework.Runtime.Extension.UIFormCoverEventArgs;
            
            public constructor();
            
        }
        
        
        class UIFormDeinitEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get FormHash(): number;
            
            
            public get FormId(): number;
            
            
            public get UserData(): any;
            
            
            public static Create($formHash: number, $formId: number, $userData: any):UnityGameFramework.Runtime.Extension.UIFormDeinitEventArgs;
            
            public constructor();
            
        }
        
        
        class UIFormInitEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get FormHash(): number;
            
            
            public get FormId(): number;
            
            
            public get FormGO(): UnityEngine.GameObject;
            
            
            public get UIForm(): UnityGameFramework.Runtime.Extension.UIForm;
            
            
            public get UserData(): any;
            
            
            public static Create($formHash: number, $formId: number, $uiForm: UnityGameFramework.Runtime.Extension.UIForm, $formGO: UnityEngine.GameObject, $userData: any):UnityGameFramework.Runtime.Extension.UIFormInitEventArgs;
            
            public constructor();
            
        }
        
        
        class UIFormOpenEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get FormHash(): number;
            
            
            public get FormId(): number;
            
            
            public get UserData(): any;
            
            
            public static Create($formHash: number, $formId: number, $userData: any):UnityGameFramework.Runtime.Extension.UIFormOpenEventArgs;
            
            public constructor();
            
        }
        
        
        class UIFormPauseEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get FormHash(): number;
            
            
            public get FormId(): number;
            
            
            public get UserData(): any;
            
            
            public static Create($formHash: number, $formId: number, $userData: any):UnityGameFramework.Runtime.Extension.UIFormPauseEventArgs;
            
            public constructor();
            
        }
        
        
        class UIFormRecycleEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get FormHash(): number;
            
            
            public get FormId(): number;
            
            
            public get UserData(): any;
            
            
            public static Create($formHash: number, $formId: number, $userData: any):UnityGameFramework.Runtime.Extension.UIFormRecycleEventArgs;
            
            public constructor();
            
        }
        
        
        class UIFormRefocusEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get FormHash(): number;
            
            
            public get FormId(): number;
            
            
            public get UserData(): any;
            
            
            public static Create($formHash: number, $formId: number, $userData: any):UnityGameFramework.Runtime.Extension.UIFormRefocusEventArgs;
            
            public constructor();
            
        }
        
        
        class UIFormResumeEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get FormHash(): number;
            
            
            public get FormId(): number;
            
            
            public get UserData(): any;
            
            
            public static Create($formHash: number, $formId: number, $userData: any):UnityGameFramework.Runtime.Extension.UIFormResumeEventArgs;
            
            public constructor();
            
        }
        
        
        class UIFormRevealEventArgs extends GameFramework.Event.GameEventArgs implements GameFramework.IReference{ 
            
            public static EventId: number;
            
            public get Id(): number;
            
            
            public get FormHash(): number;
            
            
            public get FormId(): number;
            
            
            public get UserData(): any;
            
            
            public static Create($formHash: number, $formId: number, $userData: any):UnityGameFramework.Runtime.Extension.UIFormRevealEventArgs;
            
            public constructor();
            
        }
        
        
        class SplashForm extends UnityEngine.MonoBehaviour{ 
            
        }
        
        
        class UpdateResourceForm extends UnityEngine.MonoBehaviour{ 
            
        }
        
        
        class DialogForm extends UnityEngine.MonoBehaviour{ 
            
        }
        
        
        class BuildInfo extends System.Object{ 
            
        }
        
        
    }
    namespace GameFramework.Localization {
        /** 本地化语言。 */
        enum Language{ Unspecified = 0, Afrikaans = 1, Albanian = 2, Arabic = 3, Basque = 4, Belarusian = 5, Bulgarian = 6, Catalan = 7, ChineseSimplified = 8, ChineseTraditional = 9, Croatian = 10, Czech = 11, Danish = 12, Dutch = 13, English = 14, Estonian = 15, Faroese = 16, Finnish = 17, French = 18, Georgian = 19, German = 20, Greek = 21, Hebrew = 22, Hungarian = 23, Icelandic = 24, Indonesian = 25, Italian = 26, Japanese = 27, Korean = 28, Latvian = 29, Lithuanian = 30, Macedonian = 31, Malayalam = 32, Norwegian = 33, Persian = 34, Polish = 35, PortugueseBrazil = 36, PortuguesePortugal = 37, Romanian = 38, Russian = 39, SerboCroatian = 40, SerbianCyrillic = 41, SerbianLatin = 42, Slovak = 43, Slovenian = 44, Spanish = 45, Swedish = 46, Thai = 47, Turkish = 48, Ukrainian = 49, Vietnamese = 50 }
        
        
    }
    namespace GameFramework.Resource {
        /** 资源管理器接口。 */
        interface IResourceManager{ 
            
        }
        
        /** 资源模式。 */
        enum ResourceMode{ Unspecified = 0, Package = 1, Updatable = 2, UpdatableWhilePlaying = 3 }
        
        /** 单机模式版本资源列表序列化器。 */
        class PackageVersionListSerializer extends GameFramework.GameFrameworkSerializer$1<GameFramework.Resource.PackageVersionList>{ 
            
        }
        
        /** 单机模式版本资源列表。 */
        class PackageVersionList extends System.ValueType{ 
            
        }
        
        /** 可更新模式版本资源列表序列化器。 */
        class UpdatableVersionListSerializer extends GameFramework.GameFrameworkSerializer$1<GameFramework.Resource.UpdatableVersionList>{ 
            
        }
        
        /** 可更新模式版本资源列表。 */
        class UpdatableVersionList extends System.ValueType{ 
            
        }
        
        /** 本地只读区版本资源列表序列化器。 */
        class ReadOnlyVersionListSerializer extends GameFramework.GameFrameworkSerializer$1<GameFramework.Resource.LocalVersionList>{ 
            
        }
        
        /** 本地版本资源列表。 */
        class LocalVersionList extends System.ValueType{ 
            
        }
        
        /** 本地读写区版本资源列表序列化器。 */
        class ReadWriteVersionListSerializer extends GameFramework.GameFrameworkSerializer$1<GameFramework.Resource.LocalVersionList>{ 
            
        }
        
        /** 资源包版本资源列表序列化器。 */
        class ResourcePackVersionListSerializer extends GameFramework.GameFrameworkSerializer$1<GameFramework.Resource.ResourcePackVersionList>{ 
            
        }
        
        /** 资源包版本资源列表。 */
        class ResourcePackVersionList extends System.ValueType{ 
            
        }
        
        /** 资源组接口。 */
        interface IResourceGroup{ 
            
        }
        
        /** 解密资源回调函数。 * @param bytes 要解密的资源二进制流。
         * @param startIndex 解密二进制流的起始位置。
         * @param count 解密二进制流的长度。
         * @param name 资源名称。
         * @param variant 变体名称。
         * @param extension 扩展名称。
         * @param storageInReadOnly 资源是否在只读区。
         * @param fileSystem 文件系统名称。
         * @param loadType 资源加载方式。
         * @param length 资源大小。
         * @param hashCode 资源哈希值。
         */
        interface DecryptResourceCallback { (bytes: System.Array$1<number>, startIndex: number, count: number, name: string, variant: string, extension: string, storageInReadOnly: boolean, fileSystem: string, loadType: number, length: number, hashCode: number) : void; } 
        var DecryptResourceCallback: {new (func: (bytes: System.Array$1<number>, startIndex: number, count: number, name: string, variant: string, extension: string, storageInReadOnly: boolean, fileSystem: string, loadType: number, length: number, hashCode: number) => void): DecryptResourceCallback;}
        
        /** 使用单机模式并初始化资源完成时的回调函数。 */
        interface InitResourcesCompleteCallback { () : void; } 
        var InitResourcesCompleteCallback: {new (func: () => void): InitResourcesCompleteCallback;}
        
        /** 检查版本资源列表结果。 */
        enum CheckVersionListResult{ Updated = 0, NeedUpdate = 1 }
        
        /** 版本资源列表更新回调函数集。 */
        class UpdateVersionListCallbacks extends System.Object{ 
            
        }
        
        /** 使用可更新模式并校验资源完成时的回调函数。 * @param result 校验资源结果，全部成功为 true，否则为 false。
         */
        interface VerifyResourcesCompleteCallback { (result: boolean) : void; } 
        var VerifyResourcesCompleteCallback: {new (func: (result: boolean) => void): VerifyResourcesCompleteCallback;}
        
        /** 使用可更新模式并检查资源完成时的回调函数。 * @param movedCount 已移动的资源数量。
         * @param removedCount 已移除的资源数量。
         * @param updateCount 可更新的资源数量。
         * @param updateTotalLength 可更新的资源总大小。
         * @param updateTotalCompressedLength 可更新的压缩后总大小。
         */
        interface CheckResourcesCompleteCallback { (movedCount: number, removedCount: number, updateCount: number, updateTotalLength: bigint, updateTotalCompressedLength: bigint) : void; } 
        var CheckResourcesCompleteCallback: {new (func: (movedCount: number, removedCount: number, updateCount: number, updateTotalLength: bigint, updateTotalCompressedLength: bigint) => void): CheckResourcesCompleteCallback;}
        
        /** 使用可更新模式并应用资源包资源完成时的回调函数。 * @param resourcePackPath 应用的资源包路径。
         * @param result 应用资源包资源结果，全部成功为 true，否则为 false。
         */
        interface ApplyResourcesCompleteCallback { (resourcePackPath: string, result: boolean) : void; } 
        var ApplyResourcesCompleteCallback: {new (func: (resourcePackPath: string, result: boolean) => void): ApplyResourcesCompleteCallback;}
        
        /** 使用可更新模式并更新指定资源组完成时的回调函数。 * @param resourceGroup 更新的资源组。
         * @param result 更新资源结果，全部成功为 true，否则为 false。
         */
        interface UpdateResourcesCompleteCallback { (resourceGroup: GameFramework.Resource.IResourceGroup, result: boolean) : void; } 
        var UpdateResourcesCompleteCallback: {new (func: (resourceGroup: GameFramework.Resource.IResourceGroup, result: boolean) => void): UpdateResourcesCompleteCallback;}
        
        /** 检查资源是否存在的结果。 */
        enum HasAssetResult{ NotExist = 0, NotReady = 1, AssetOnDisk = 2, AssetOnFileSystem = 3, BinaryOnDisk = 4, BinaryOnFileSystem = 5 }
        
        /** 加载资源回调函数集。 */
        class LoadAssetCallbacks extends System.Object{ 
            
        }
        
        /** 加载二进制资源回调函数集。 */
        class LoadBinaryCallbacks extends System.Object{ 
            
        }
        
        /** 资源组集合接口。 */
        interface IResourceGroupCollection{ 
            
        }
        
        
    }
    namespace GameFramework {
        /** 任务信息。 */
        class TaskInfo extends System.ValueType{ 
            
        }
        
        /** 事件基类。 */
        class BaseEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        /** 游戏框架中包含事件数据的类的基类。 */
        class GameFrameworkEventArgs extends System.EventArgs implements GameFramework.IReference{ 
            
        }
        
        /** 引用接口。 */
        interface IReference{ 
            
        }
        
        
        class GameFrameworkSerializer$1<T> extends System.Object{ 
            
        }
        
        
    }
    namespace GameFramework.Event {
        /** 游戏逻辑事件基类。 */
        class GameEventArgs extends GameFramework.BaseEventArgs implements GameFramework.IReference{ 
            
        }
        
        
    }
    namespace GameFramework.Download {
        /** 下载开始事件。 */
        class DownloadStartEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        /** 下载成功事件。 */
        class DownloadSuccessEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        /** 下载失败事件。 */
        class DownloadFailureEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        
    }
    namespace GameFramework.Entity {
        /** 实体组接口。 */
        interface IEntityGroup{ 
            
        }
        
        /** 实体接口。 */
        interface IEntity{ 
            
        }
        
        /** 显示实体成功事件。 */
        class ShowEntitySuccessEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        /** 显示实体失败事件。 */
        class ShowEntityFailureEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        /** 隐藏实体完成事件。 */
        class HideEntityCompleteEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        
    }
    namespace GameFramework.Network {
        /** 网络频道接口。 */
        interface INetworkChannel{ 
            
        }
        
        /** 网络服务类型。 */
        enum ServiceType{ Tcp = 0, TcpWithSyncReceive = 1 }
        
        /** 网络频道辅助器接口。 */
        interface INetworkChannelHelper{ 
            
        }
        
        
    }
    namespace UnityEngine.Audio {
        /** AudioMixer asset. */
        class AudioMixer extends UnityEngine.Object{ 
            
        }
        
        
    }
    namespace GameFramework.Sound {
        /** 声音组接口。 */
        interface ISoundGroup{ 
            
        }
        
        /** 播放声音参数。 */
        class PlaySoundParams extends System.Object implements GameFramework.IReference{ 
            
        }
        
        /** 声音代理接口。 */
        interface ISoundAgent{ 
            
        }
        
        /** 播放声音成功事件。 */
        class PlaySoundSuccessEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        /** 播放声音错误码。 */
        enum PlaySoundErrorCode{ Unknown = 0, SoundGroupNotExist = 1, SoundGroupHasNoAgent = 2, LoadAssetFailure = 3, IgnoredDueToLowPriority = 4, SetSoundAssetFailure = 5 }
        
        /** 播放声音失败事件。 */
        class PlaySoundFailureEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        
    }
    namespace GameFramework.UI {
        /** 界面组接口。 */
        interface IUIGroup{ 
            
        }
        
        /** 界面接口。 */
        interface IUIForm{ 
            
        }
        
        /** 打开界面成功事件。 */
        class OpenUIFormSuccessEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        /** 打开界面失败事件。 */
        class OpenUIFormFailureEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        /** 关闭界面完成事件。 */
        class CloseUIFormCompleteEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        
    }
    namespace GameFramework.WebRequest {
        /** Web 请求开始事件。 */
        class WebRequestStartEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        /** Web 请求成功事件。 */
        class WebRequestSuccessEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        /** Web 请求失败事件。 */
        class WebRequestFailureEventArgs extends GameFramework.GameFrameworkEventArgs implements GameFramework.IReference{ 
            
        }
        
        
    }
    
}