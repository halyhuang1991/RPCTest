@rem 生成客户端和服务器端存根

setlocal

@rem 进入当前目录
cd /d %~dp0

set TOOLS_PATH=C:\Users\haly\.nuget\packages\Grpc.Tools\1.0.0\tools\windows_x86

%TOOLS_PATH%\protoc.exe ^
--proto_path protos ^
--cpp_out=Interfaces/cpp ^
--csharp_out=Interfaces/csharp ^
--java_out=Interfaces/java ^
--js_out=Interfaces/javascript ^
--grpc_out=Interfaces/csharp ^
--plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe ^
protos/mathservice.proto

endlocal
timeout 5