// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: src/Nethermind/Nethermind.Grpc/Nethermind.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Nethermind.Grpc {

  /// <summary>Holder for reflection information generated from src/Nethermind/Nethermind.Grpc/Nethermind.proto</summary>
  public static partial class NethermindReflection {

    #region Descriptor
    /// <summary>File descriptor for src/Nethermind/Nethermind.Grpc/Nethermind.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static NethermindReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ci9zcmMvTmV0aGVybWluZC9OZXRoZXJtaW5kLkdycGMvTmV0aGVybWluZC5w",
            "cm90bxIPTmV0aGVybWluZC5HcnBjIiwKDFF1ZXJ5UmVxdWVzdBIOCgZjbGll",
            "bnQYASABKAkSDAoEYXJncxgCIAMoCSItCg1RdWVyeVJlc3BvbnNlEg4KBmNs",
            "aWVudBgBIAEoCRIMCgRkYXRhGAIgASgJIjMKE1N1YnNjcmlwdGlvblJlcXVl",
            "c3QSDgoGY2xpZW50GAEgASgJEgwKBGFyZ3MYAiADKAkiNAoUU3Vic2NyaXB0",
            "aW9uUmVzcG9uc2USDgoGY2xpZW50GAEgASgJEgwKBGRhdGEYAiABKAkyuwEK",
            "EU5ldGhlcm1pbmRTZXJ2aWNlEkgKBVF1ZXJ5Eh0uTmV0aGVybWluZC5HcnBj",
            "LlF1ZXJ5UmVxdWVzdBoeLk5ldGhlcm1pbmQuR3JwYy5RdWVyeVJlc3BvbnNl",
            "IgASXAoJU3Vic2NyaWJlEiQuTmV0aGVybWluZC5HcnBjLlN1YnNjcmlwdGlv",
            "blJlcXVlc3QaJS5OZXRoZXJtaW5kLkdycGMuU3Vic2NyaXB0aW9uUmVzcG9u",
            "c2UiADABYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Nethermind.Grpc.QueryRequest), global::Nethermind.Grpc.QueryRequest.Parser, new[]{ "Client", "Args" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Nethermind.Grpc.QueryResponse), global::Nethermind.Grpc.QueryResponse.Parser, new[]{ "Client", "Data" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Nethermind.Grpc.SubscriptionRequest), global::Nethermind.Grpc.SubscriptionRequest.Parser, new[]{ "Client", "Args" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Nethermind.Grpc.SubscriptionResponse), global::Nethermind.Grpc.SubscriptionResponse.Parser, new[]{ "Client", "Data" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class QueryRequest : pb::IMessage<QueryRequest> {
    private static readonly pb::MessageParser<QueryRequest> _parser = new pb::MessageParser<QueryRequest>(() => new QueryRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<QueryRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Nethermind.Grpc.NethermindReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QueryRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QueryRequest(QueryRequest other) : this() {
      client_ = other.client_;
      args_ = other.args_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QueryRequest Clone() {
      return new QueryRequest(this);
    }

    /// <summary>Field number for the "client" field.</summary>
    public const int ClientFieldNumber = 1;
    private string client_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Client {
      get { return client_; }
      set {
        client_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "args" field.</summary>
    public const int ArgsFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _repeated_args_codec
        = pb::FieldCodec.ForString(18);
    private readonly pbc::RepeatedField<string> args_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> Args {
      get { return args_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as QueryRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(QueryRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Client != other.Client) return false;
      if(!args_.Equals(other.args_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Client.Length != 0) hash ^= Client.GetHashCode();
      hash ^= args_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Client.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Client);
      }
      args_.WriteTo(output, _repeated_args_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Client.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Client);
      }
      size += args_.CalculateSize(_repeated_args_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(QueryRequest other) {
      if (other == null) {
        return;
      }
      if (other.Client.Length != 0) {
        Client = other.Client;
      }
      args_.Add(other.args_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Client = input.ReadString();
            break;
          }
          case 18: {
            args_.AddEntriesFrom(input, _repeated_args_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class QueryResponse : pb::IMessage<QueryResponse> {
    private static readonly pb::MessageParser<QueryResponse> _parser = new pb::MessageParser<QueryResponse>(() => new QueryResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<QueryResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Nethermind.Grpc.NethermindReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QueryResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QueryResponse(QueryResponse other) : this() {
      client_ = other.client_;
      data_ = other.data_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QueryResponse Clone() {
      return new QueryResponse(this);
    }

    /// <summary>Field number for the "client" field.</summary>
    public const int ClientFieldNumber = 1;
    private string client_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Client {
      get { return client_; }
      set {
        client_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "data" field.</summary>
    public const int DataFieldNumber = 2;
    private string data_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Data {
      get { return data_; }
      set {
        data_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as QueryResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(QueryResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Client != other.Client) return false;
      if (Data != other.Data) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Client.Length != 0) hash ^= Client.GetHashCode();
      if (Data.Length != 0) hash ^= Data.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Client.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Client);
      }
      if (Data.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Data);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Client.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Client);
      }
      if (Data.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Data);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(QueryResponse other) {
      if (other == null) {
        return;
      }
      if (other.Client.Length != 0) {
        Client = other.Client;
      }
      if (other.Data.Length != 0) {
        Data = other.Data;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Client = input.ReadString();
            break;
          }
          case 18: {
            Data = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class SubscriptionRequest : pb::IMessage<SubscriptionRequest> {
    private static readonly pb::MessageParser<SubscriptionRequest> _parser = new pb::MessageParser<SubscriptionRequest>(() => new SubscriptionRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SubscriptionRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Nethermind.Grpc.NethermindReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscriptionRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscriptionRequest(SubscriptionRequest other) : this() {
      client_ = other.client_;
      args_ = other.args_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscriptionRequest Clone() {
      return new SubscriptionRequest(this);
    }

    /// <summary>Field number for the "client" field.</summary>
    public const int ClientFieldNumber = 1;
    private string client_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Client {
      get { return client_; }
      set {
        client_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "args" field.</summary>
    public const int ArgsFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _repeated_args_codec
        = pb::FieldCodec.ForString(18);
    private readonly pbc::RepeatedField<string> args_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> Args {
      get { return args_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SubscriptionRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SubscriptionRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Client != other.Client) return false;
      if(!args_.Equals(other.args_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Client.Length != 0) hash ^= Client.GetHashCode();
      hash ^= args_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Client.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Client);
      }
      args_.WriteTo(output, _repeated_args_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Client.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Client);
      }
      size += args_.CalculateSize(_repeated_args_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SubscriptionRequest other) {
      if (other == null) {
        return;
      }
      if (other.Client.Length != 0) {
        Client = other.Client;
      }
      args_.Add(other.args_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Client = input.ReadString();
            break;
          }
          case 18: {
            args_.AddEntriesFrom(input, _repeated_args_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class SubscriptionResponse : pb::IMessage<SubscriptionResponse> {
    private static readonly pb::MessageParser<SubscriptionResponse> _parser = new pb::MessageParser<SubscriptionResponse>(() => new SubscriptionResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SubscriptionResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Nethermind.Grpc.NethermindReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscriptionResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscriptionResponse(SubscriptionResponse other) : this() {
      client_ = other.client_;
      data_ = other.data_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscriptionResponse Clone() {
      return new SubscriptionResponse(this);
    }

    /// <summary>Field number for the "client" field.</summary>
    public const int ClientFieldNumber = 1;
    private string client_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Client {
      get { return client_; }
      set {
        client_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "data" field.</summary>
    public const int DataFieldNumber = 2;
    private string data_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Data {
      get { return data_; }
      set {
        data_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SubscriptionResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SubscriptionResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Client != other.Client) return false;
      if (Data != other.Data) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Client.Length != 0) hash ^= Client.GetHashCode();
      if (Data.Length != 0) hash ^= Data.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Client.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Client);
      }
      if (Data.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Data);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Client.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Client);
      }
      if (Data.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Data);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SubscriptionResponse other) {
      if (other == null) {
        return;
      }
      if (other.Client.Length != 0) {
        Client = other.Client;
      }
      if (other.Data.Length != 0) {
        Data = other.Data;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Client = input.ReadString();
            break;
          }
          case 18: {
            Data = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
