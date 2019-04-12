// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: MathService.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

public static partial class MathService
{
  static readonly string __ServiceName = "MathService";

  static readonly grpc::Marshaller<global::AddRequest> __Marshaller_AddRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AddRequest.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::AddReply> __Marshaller_AddReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AddReply.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::MultiplyRequest> __Marshaller_MultiplyRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MultiplyRequest.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::MultiplyReply> __Marshaller_MultiplyReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::MultiplyReply.Parser.ParseFrom);

  static readonly grpc::Method<global::AddRequest, global::AddReply> __Method_Add = new grpc::Method<global::AddRequest, global::AddReply>(
      grpc::MethodType.Unary,
      __ServiceName,
      "Add",
      __Marshaller_AddRequest,
      __Marshaller_AddReply);

  static readonly grpc::Method<global::MultiplyRequest, global::MultiplyReply> __Method_Multiply = new grpc::Method<global::MultiplyRequest, global::MultiplyReply>(
      grpc::MethodType.Unary,
      __ServiceName,
      "Multiply",
      __Marshaller_MultiplyRequest,
      __Marshaller_MultiplyReply);

  /// <summary>Service descriptor</summary>
  public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
  {
    get { return global::MathServiceReflection.Descriptor.Services[0]; }
  }

  /// <summary>Base class for server-side implementations of MathService</summary>
  public abstract partial class MathServiceBase
  {
    public virtual global::System.Threading.Tasks.Task<global::AddReply> Add(global::AddRequest request, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

    public virtual global::System.Threading.Tasks.Task<global::MultiplyReply> Multiply(global::MultiplyRequest request, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

  }

  /// <summary>Client for MathService</summary>
  public partial class MathServiceClient : grpc::ClientBase<MathServiceClient>
  {
    /// <summary>Creates a new client for MathService</summary>
    /// <param name="channel">The channel to use to make remote calls.</param>
    public MathServiceClient(grpc::Channel channel) : base(channel)
    {
    }
    /// <summary>Creates a new client for MathService that uses a custom <c>CallInvoker</c>.</summary>
    /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
    public MathServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
    {
    }
    /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
    protected MathServiceClient() : base()
    {
    }
    /// <summary>Protected constructor to allow creation of configured clients.</summary>
    /// <param name="configuration">The client configuration.</param>
    protected MathServiceClient(ClientBaseConfiguration configuration) : base(configuration)
    {
    }

    public virtual global::AddReply Add(global::AddRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return Add(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual global::AddReply Add(global::AddRequest request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_Add, null, options, request);
    }
    public virtual grpc::AsyncUnaryCall<global::AddReply> AddAsync(global::AddRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return AddAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncUnaryCall<global::AddReply> AddAsync(global::AddRequest request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_Add, null, options, request);
    }
    public virtual global::MultiplyReply Multiply(global::MultiplyRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return Multiply(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual global::MultiplyReply Multiply(global::MultiplyRequest request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_Multiply, null, options, request);
    }
    public virtual grpc::AsyncUnaryCall<global::MultiplyReply> MultiplyAsync(global::MultiplyRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return MultiplyAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncUnaryCall<global::MultiplyReply> MultiplyAsync(global::MultiplyRequest request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_Multiply, null, options, request);
    }
    /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
    protected override MathServiceClient NewInstance(ClientBaseConfiguration configuration)
    {
      return new MathServiceClient(configuration);
    }
  }

  /// <summary>Creates service definition that can be registered with a server</summary>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  public static grpc::ServerServiceDefinition BindService(MathServiceBase serviceImpl)
  {
    return grpc::ServerServiceDefinition.CreateBuilder()
        .AddMethod(__Method_Add, serviceImpl.Add)
        .AddMethod(__Method_Multiply, serviceImpl.Multiply).Build();
  }

  /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
  /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
  /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  public static void BindService(grpc::ServiceBinderBase serviceBinder, MathServiceBase serviceImpl)
  {
    serviceBinder.AddMethod(__Method_Add, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::AddRequest, global::AddReply>(serviceImpl.Add));
    serviceBinder.AddMethod(__Method_Multiply, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::MultiplyRequest, global::MultiplyReply>(serviceImpl.Multiply));
  }

}
#endregion
