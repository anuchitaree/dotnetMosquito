using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Protocol;
using System.Text;
using System.Text.Json;


namespace dotnetMosquito
{
    internal class Program
    {
        static async Task Main(string[] args)
        { 

            var mqttFactory = new MqttFactory();
            var mqttClient = mqttFactory.CreateMqttClient();

            // สร้าง options สำหรับ MQTTnet v3
            var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer("127.0.0.1", 30080)
                    .Build();

            // เชื่อมต่อ
            Console.WriteLine("Connecting...");
            await mqttClient.ConnectAsync(mqttClientOptions);


            Int128 running = 0;
                
            // เริ่ม loop scheduler
            while (true)
            {
                // สร้าง JSON payload


                var payload = JsonSerializer.Serialize(new
                {
                    time = "2025-12-30T23:34:05Z",
                    a0 = running,
                    a1 = 12.234,
                    a2 = 12.234,
                    a3 = 12.234,
                    a4 = 12.234,
                    a5 = 12.234,
                    a6 = 12.234,
                    a7 = 12.234,
                    a8 = 12.234,
                    a9 = 12.234,
                    b0 = 12.234,
                    b1 = 12.234,
                    b2 = 12.234,
                    b3 = 12.234,
                    b4 = 12.234,
                    b5 = 12.234,
                    b6 = 12.234,
                    b7 = 12.234,
                    b8 = 12.234,
                    b9 = 12.234,
                    c0 = 12.234,
                    c1 = 12.234,
                    c2 = 12.234,
                    c3 = 12.234,
                    c4 = 12.234,
                    c5 = 12.234,
                    c6 = 12.234,
                    c7 = 12.234,
                    c8 = 12.234,
                    c9 = 12.234,
                    d0 = 12.234,
                    d1 = 12.234,
                    d2 = 12.234,
                    d3 = 12.234,
                    d4 = 12.234,
                    d5 = 12.234,
                    d6 = 12.234,
                    d7 = 12.234,
                    d8 = 12.234,
                    d9 = 12.234,
                    e0 = 12.234,
                    e1 = 12.234,
                    e2 = 12.234,
                    e3 = 12.234,
                    e4 = 12.234,
                    e5 = 12.234,
                    e6 = 12.234,
                    e7 = 12.234,
                    e8 = 12.234,
                    e9 = 12.234,
                    f0 = 12.234,
                    f1 = 12.234,
                    f2 = 12.234,
                    f3 = 12.234,
                    f4 = 12.234,
                    f5 = 12.234,
                    f6 = 12.234,
                    f7 = 12.234,
                    f8 = 12.234,
                    f9 = 12.234,
                    g0 = 12.234,
                    g1 = 12.234,
                    g2 = 12.234,
                    g3 = 12.234,
                    g4 = 12.234,
                    g5 = 12.234,
                    g6 = 12.234,
                    g7 = 12.234,
                    g8 = 12.234,
                    g9 = 12.234,
                    h0 = 12.234,
                    h1 = 12.234,
                    h2 = 12.234,
                    h3 = 12.234,
                    h4 = 12.234,
                    h5 = 12.234,
                    h6 = 12.234,
                    h7 = 12.234,
                    h8 = 12.234,
                    h9 = 12.234,
                    i0 = 12.234,
                    i1 = 12.234,
                    i2 = 12.234,
                    i3 = 12.234,
                    i4 = 12.234,
                    i5 = 12.234,
                    i6 = 12.234,
                    i7 = 12.234,
                    i8 = 12.234,
                    i9 = 12.234,
                    j0 = 12.234,
                    j1 = 12.234,
                    j2 = 12.234,
                    j3 = 12.234,
                    j4 = 12.234,
                    j5 = 12.234,
                    j6 = 12.234,
                    j7 = 12.234,
                    j8 = 12.234,
                    j9 = 12.234,
                    k0 = 12.234,
                    k1 = 12.234,
                    k2 = 12.234,
                    k3 = 12.234,
                    k4 = 12.234,
                    k5 = 12.234, 
                    k6 = 12.234,
                    k7 = 12.234,
                    k8 = 12.234,
                    k9 = 12.234,


                });

                // สร้าง message
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic("test/device/json")
                    .WithPayload(Encoding.UTF8.GetBytes(payload))
                    .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                    .Build();

                // ส่ง message
                Console.WriteLine($"Publishing...{running}");
                await mqttClient.PublishAsync(message);

                await Task.Delay(TimeSpan.FromMilliseconds(1000));
                running++;
            }
            // ตัดการเชื่อมต่อ
            //await mqttClient.DisconnectAsync();
            //Console.WriteLine("Done!");

        }
    }
}
