// <copyright file="riak_dt.cs" company="Basho Technologies, Inc.">
// Copyright (c) 2011 - OJ Reeves & Jeremiah Peschka
// Copyright (c) 2014 - Basho Technologies, Inc.
//
// This file is provided to you under the Apache License,
// Version 2.0 (the "License"); you may not use this file
// except in compliance with the License.  You may obtain
// a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.
// </copyright>

#pragma warning disable 1591
namespace RiakClient.Messages
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MapField")]
  public partial class MapField : global::ProtoBuf.IExtensible
  {
    public MapField() {}
    
    private byte[] _name;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] name
    {
      get { return _name; }
      set { _name = value; }
    }
    private MapField.MapFieldType _type;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public MapField.MapFieldType type
    {
      get { return _type; }
      set { _type = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"MapFieldType")]
    public enum MapFieldType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"COUNTER", Value=1)]
      COUNTER = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET", Value=2)]
      SET = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"REGISTER", Value=3)]
      REGISTER = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FLAG", Value=4)]
      FLAG = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAP", Value=5)]
      MAP = 5
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MapEntry")]
  public partial class MapEntry : global::ProtoBuf.IExtensible
  {
    public MapEntry() {}
    
    private MapField _field;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"field", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MapField field
    {
      get { return _field; }
      set { _field = value; }
    }
    private long _counter_value = default(long);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"counter_value", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long counter_value
    {
      get { return _counter_value; }
      set { _counter_value = value; }
    }
    private readonly global::System.Collections.Generic.List<byte[]> _set_value = new global::System.Collections.Generic.List<byte[]>();
    [global::ProtoBuf.ProtoMember(3, Name=@"set_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<byte[]> set_value
    {
      get { return _set_value; }
    }
  
    private byte[] _register_value = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"register_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] register_value
    {
      get { return _register_value; }
      set { _register_value = value; }
    }
    private bool _flag_value = default(bool);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"flag_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool flag_value
    {
      get { return _flag_value; }
      set { _flag_value = value; }
    }
    private readonly global::System.Collections.Generic.List<MapEntry> _map_value = new global::System.Collections.Generic.List<MapEntry>();
    [global::ProtoBuf.ProtoMember(6, Name=@"map_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<MapEntry> map_value
    {
      get { return _map_value; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DtFetchReq")]
  public partial class DtFetchReq : global::ProtoBuf.IExtensible
  {
    public DtFetchReq() {}
    
    private byte[] _bucket;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"bucket", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] bucket
    {
      get { return _bucket; }
      set { _bucket = value; }
    }
    private byte[] _key;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] key
    {
      get { return _key; }
      set { _key = value; }
    }
    private byte[] _type;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] type
    {
      get { return _type; }
      set { _type = value; }
    }
    private uint _r = default(uint);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"r", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint r
    {
      get { return _r; }
      set { _r = value; }
    }
    private uint _pr = default(uint);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"pr", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint pr
    {
      get { return _pr; }
      set { _pr = value; }
    }
    private bool _basic_quorum = default(bool);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"basic_quorum", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool basic_quorum
    {
      get { return _basic_quorum; }
      set { _basic_quorum = value; }
    }
    private bool _notfound_ok = default(bool);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"notfound_ok", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool notfound_ok
    {
      get { return _notfound_ok; }
      set { _notfound_ok = value; }
    }
    private uint _timeout = default(uint);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"timeout", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint timeout
    {
      get { return _timeout; }
      set { _timeout = value; }
    }
    private bool _sloppy_quorum = default(bool);
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"sloppy_quorum", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool sloppy_quorum
    {
      get { return _sloppy_quorum; }
      set { _sloppy_quorum = value; }
    }
    private uint _n_val = default(uint);
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"n_val", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint n_val
    {
      get { return _n_val; }
      set { _n_val = value; }
    }
    private bool _include_context = (bool)true;
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"include_context", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)true)]
    public bool include_context
    {
      get { return _include_context; }
      set { _include_context = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DtValue")]
  public partial class DtValue : global::ProtoBuf.IExtensible
  {
    public DtValue() {}
    
    private long _counter_value = default(long);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"counter_value", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long counter_value
    {
      get { return _counter_value; }
      set { _counter_value = value; }
    }
    private readonly global::System.Collections.Generic.List<byte[]> _set_value = new global::System.Collections.Generic.List<byte[]>();
    [global::ProtoBuf.ProtoMember(2, Name=@"set_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<byte[]> set_value
    {
      get { return _set_value; }
    }
  
    private readonly global::System.Collections.Generic.List<MapEntry> _map_value = new global::System.Collections.Generic.List<MapEntry>();
    [global::ProtoBuf.ProtoMember(3, Name=@"map_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<MapEntry> map_value
    {
      get { return _map_value; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DtFetchResp")]
  public partial class DtFetchResp : global::ProtoBuf.IExtensible
  {
    public DtFetchResp() {}
    
    private byte[] _context = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"context", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] context
    {
      get { return _context; }
      set { _context = value; }
    }
    private DtFetchResp.DataType _type;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public DtFetchResp.DataType type
    {
      get { return _type; }
      set { _type = value; }
    }
    private DtValue _value = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public DtValue value
    {
      get { return _value; }
      set { _value = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"DataType")]
    public enum DataType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"COUNTER", Value=1)]
      COUNTER = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET", Value=2)]
      SET = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAP", Value=3)]
      MAP = 3
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CounterOp")]
  public partial class CounterOp : global::ProtoBuf.IExtensible
  {
    public CounterOp() {}
    
    private long _increment = default(long);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"increment", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long increment
    {
      get { return _increment; }
      set { _increment = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SetOp")]
  public partial class SetOp : global::ProtoBuf.IExtensible
  {
    public SetOp() {}
    
    private readonly global::System.Collections.Generic.List<byte[]> _adds = new global::System.Collections.Generic.List<byte[]>();
    [global::ProtoBuf.ProtoMember(1, Name=@"adds", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<byte[]> adds
    {
      get { return _adds; }
    }
  
    private readonly global::System.Collections.Generic.List<byte[]> _removes = new global::System.Collections.Generic.List<byte[]>();
    [global::ProtoBuf.ProtoMember(2, Name=@"removes", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<byte[]> removes
    {
      get { return _removes; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MapUpdate")]
  public partial class MapUpdate : global::ProtoBuf.IExtensible
  {
    public MapUpdate() {}
    
    private MapField _field;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"field", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MapField field
    {
      get { return _field; }
      set { _field = value; }
    }
    private CounterOp _counter_op = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"counter_op", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public CounterOp counter_op
    {
      get { return _counter_op; }
      set { _counter_op = value; }
    }
    private SetOp _set_op = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"set_op", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public SetOp set_op
    {
      get { return _set_op; }
      set { _set_op = value; }
    }
    private byte[] _register_op = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"register_op", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] register_op
    {
      get { return _register_op; }
      set { _register_op = value; }
    }
    private MapUpdate.FlagOp _flag_op = MapUpdate.FlagOp.ENABLE;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"flag_op", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    // @alexmoore - if the next line is uncommented, protobuf-net will not include the field if it's set to ENABLE, causing problems on Riak's side.
    //[global::System.ComponentModel.DefaultValue(MapUpdate.FlagOp.ENABLE)]
    public MapUpdate.FlagOp flag_op
    {
      get { return _flag_op; }
      set { _flag_op = value; }
    }
    private MapOp _map_op = null;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"map_op", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public MapOp map_op
    {
      get { return _map_op; }
      set { _map_op = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"FlagOp")]
    public enum FlagOp
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"ENABLE", Value=1)]
      ENABLE = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DISABLE", Value=2)]
      DISABLE = 2
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MapOp")]
  public partial class MapOp : global::ProtoBuf.IExtensible
  {
    public MapOp() {}
    
    private readonly global::System.Collections.Generic.List<MapField> _removes = new global::System.Collections.Generic.List<MapField>();
    [global::ProtoBuf.ProtoMember(1, Name=@"removes", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<MapField> removes
    {
      get { return _removes; }
    }
  
    private readonly global::System.Collections.Generic.List<MapUpdate> _updates = new global::System.Collections.Generic.List<MapUpdate>();
    [global::ProtoBuf.ProtoMember(2, Name=@"updates", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<MapUpdate> updates
    {
      get { return _updates; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DtOp")]
  public partial class DtOp : global::ProtoBuf.IExtensible
  {
    public DtOp() {}
    
    private CounterOp _counter_op = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"counter_op", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public CounterOp counter_op
    {
      get { return _counter_op; }
      set { _counter_op = value; }
    }
    private SetOp _set_op = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"set_op", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public SetOp set_op
    {
      get { return _set_op; }
      set { _set_op = value; }
    }
    private MapOp _map_op = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"map_op", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public MapOp map_op
    {
      get { return _map_op; }
      set { _map_op = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DtUpdateReq")]
  public partial class DtUpdateReq : global::ProtoBuf.IExtensible
  {
    public DtUpdateReq() {}
    
    private byte[] _bucket;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"bucket", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] bucket
    {
      get { return _bucket; }
      set { _bucket = value; }
    }
    private byte[] _key = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] key
    {
      get { return _key; }
      set { _key = value; }
    }
    private byte[] _type;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] type
    {
      get { return _type; }
      set { _type = value; }
    }
    private byte[] _context = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"context", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] context
    {
      get { return _context; }
      set { _context = value; }
    }
    private DtOp _op;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"op", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public DtOp op
    {
      get { return _op; }
      set { _op = value; }
    }
    private uint _w = default(uint);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"w", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint w
    {
      get { return _w; }
      set { _w = value; }
    }
    private uint _dw = default(uint);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"dw", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint dw
    {
      get { return _dw; }
      set { _dw = value; }
    }
    private uint _pw = default(uint);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"pw", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint pw
    {
      get { return _pw; }
      set { _pw = value; }
    }
    private bool _return_body = (bool)false;
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"return_body", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)false)]
    public bool return_body
    {
      get { return _return_body; }
      set { _return_body = value; }
    }
    private uint _timeout = default(uint);
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"timeout", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint timeout
    {
      get { return _timeout; }
      set { _timeout = value; }
    }
    private bool _sloppy_quorum = default(bool);
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"sloppy_quorum", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool sloppy_quorum
    {
      get { return _sloppy_quorum; }
      set { _sloppy_quorum = value; }
    }
    private uint _n_val = default(uint);
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"n_val", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint n_val
    {
      get { return _n_val; }
      set { _n_val = value; }
    }
    private bool _include_context = (bool)true;
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"include_context", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)true)]
    public bool include_context
    {
      get { return _include_context; }
      set { _include_context = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DtUpdateResp")]
  public partial class DtUpdateResp : global::ProtoBuf.IExtensible
  {
    public DtUpdateResp() {}
    
    private byte[] _key = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] key
    {
      get { return _key; }
      set { _key = value; }
    }
    private byte[] _context = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"context", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] context
    {
      get { return _context; }
      set { _context = value; }
    }
    private long _counter_value = default(long);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"counter_value", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long counter_value
    {
      get { return _counter_value; }
      set { _counter_value = value; }
    }
    private readonly global::System.Collections.Generic.List<byte[]> _set_value = new global::System.Collections.Generic.List<byte[]>();
    [global::ProtoBuf.ProtoMember(4, Name=@"set_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<byte[]> set_value
    {
      get { return _set_value; }
    }
  
    private readonly global::System.Collections.Generic.List<MapEntry> _map_value = new global::System.Collections.Generic.List<MapEntry>();
    [global::ProtoBuf.ProtoMember(5, Name=@"map_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<MapEntry> map_value
    {
      get { return _map_value; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
