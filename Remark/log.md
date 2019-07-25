# 服务端的ssl
    ''' 
        public static void RpcServerSsl()
        {
            var cacert = File.ReadAllText(CombinePath("ca.crt"));
            var servercert = File.ReadAllText(CombinePath("server.crt"));
            var serverkey = File.ReadAllText(CombinePath("server.key"));
            var keypair = new KeyCertificatePair(servercert, serverkey);
            var sslCredentials = new SslServerCredentials(new List<KeyCertificatePair>() { keypair }, cacert, false);

            var server = new Server
            {
                Services = { MathService.BindService(new MathServiceImpl()) },
                Ports = { new ServerPort("KEKYK", sslPort, sslCredentials) }
            };
            server.Start();
            server.Ports.ToList().ForEach(a => Console.WriteLine($"Server (SSL) listening on port {a.Port}..."));
            Console.ReadLine();
        }
    '''
# 客户端的认证
    ''' 
        public static void RpcClientSsl()
        {
            var cacert = File.ReadAllText(CombinePath("ca.crt"));
            var clientcert = File.ReadAllText(CombinePath("client.crt"));
            var clientkey = File.ReadAllText(CombinePath("client.key"));
            var ssl = new SslCredentials(cacert, new KeyCertificatePair(clientcert, clientkey));
            var channel = new Channel("KEKYK", sslPort, ssl);
            var client = new MathService.MathServiceClient(channel);

            var random = new Random();
            while (true)
            {
                var first = random.NextDouble();
                var second = random.NextDouble();

                var reply = client.AddAsync(new AddRequest { First = first, Second = second }, new CallOptions()).ResponseAsync.Result;
                Console.WriteLine($"RPC call Add service: {first:F4} + {second:F4} = {reply.Sum:F4}");
                Thread.Sleep(1000);
            }
        }

    '''