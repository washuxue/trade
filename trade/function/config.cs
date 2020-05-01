using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// config 的摘要说明
/// </summary>
public class config
{
    public config()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    //NATAPP内网穿透地址
    public static string nataddress = "http://ahugoodstrading.natapp1.cc/";

    // 应用ID,您的APPID
    public static string app_id = "2016101700709209";

    // 支付宝网关
    public static string gatewayUrl = "https://openapi.alipaydev.com/gateway.do";

    // 商户私钥，您的原始格式RSA私钥
    public static string private_key = "MIIEpAIBAAKCAQEAzSedawUXTDkkTxydyRGBmMLT169IhlQKiyyni20H5vlcVwkjCa7syrEdNkuWgHjkLvbML2Ppzy9z8APLPjh9+P3yPLFhoumj5mBXqGUCO0FXX6a3IZy3Bxxby7Q1MIUL8Jn+m5yAruCpgrBFdTYP/5Hazuu9g11ZUTMiBPyaOcwzRg8SbSHnVupjyqhzj07+/P+gEWZkZ1H3/E/Q4Mxpsk/WuH+GVFUzJQQ71OFimHtqxHXZCtpDCH/O/3nrckWupyR6B4zA0nvNr2Pe6Vifhs6rdZTE2Vv4bYqLGekt51fmTwf+Uh6GcKYaCEAbij0+/Qr9HeXwgCyjcz8m6gYNdQIDAQABAoIBAQCvBmUesLE3rmhztg5HRFA0a8Mf98MAFyMHqYknQlXDkGpfNsRVto7+PiyV7dbwtDK4foWkyLDouatH0XTMGJYgn0bS0OJjgsD6AqfGWqaUtyI70JfcbT8ZKfCG0a+vPVL6aeb2C4cdqz3y6T/Yx87OUzlB341HTZSt2dnkNz28oBr1Q0+8HTUcoa3YPlsA8B94nWUQsjCWG1T6+z32uiuoTa7kFKxxpdcVRiAMtqzZcuNmloWJgntRdnaU2MiGqvdAEnE1dH8AeOwDBgPLKwujhUNly72kvbgK+fBauQKccQY5KdLrtBvfZtmCIr3KRnGnehOVRFK4MOaadvhhiwYBAoGBAOWCbliT7CLWkYLOO3VTVuMsAi76hNTtbHlXh96p/NVHTMFuftNCBcqvRcwpVH0V5sCLkFtZHCQPOtOu+9fMlIokwmAdizzv0Vg7tmCop0kzVam4aCQBJY02HN0HTGpduxTwAcE5v0+voTypVmy1ZV/l8EjfhQK3R4hqQz4RyxnFAoGBAOTVjB4ayjghcm8+hZfJRP20NsbYuaEFJFX+Q79v85M8DCu8DJCcgDssGITm5SpMexzBHGEDf5wd7Uqsngd9KhB++A3v1ybTNXH9nPqaSuQyWx9bmUEOvNynP2b9ukMqJAo1mMXE739WKOdK7jmrP/1a9fOBQ3qtAPL79Ii6U0/xAoGBANGLcKw3AlYcieZf3TGV0bLAL44s9LJjw7JWFJtboJgp7Q5+kBTaJueTd6qb4aQDJxeNVVPR3DugHBnBnfa9trEaNs4Cq2oLm5tviWhfE71lvUSkNZEJ6vsu+NNlIoPK6FCJgVCmJOHgfNoh0eKXC+Ou0N/4FD0SkaEfRB2bqU/xAoGAMZs1b8VA9yARDZqRHVFtWk453atXuldCBD5Fc3eSZuWKgeSXGLZEeg9aFV10alIAEkCupT076Zz3NsvqyhbRCphrr6HBk1IP8PEYmZ7fA08DP+38cAUA3hiHfw0b1rmI7Imn35+Mh58m6NTuhaPhEEwqqynnde2RGhuSbB1wOBECgYAQj+DoNGrqWs0xbuVw/vYAOysTIZwkcBGzmyUiXHKouW4fpY0IMcVwLzKhO5+PKMAADl+1iFwYKES9W/p2gZbOUleewNQGF286eZsVJzlkIVInF3pY7AdMYB1s3EiunOpbdtB9FehqfbkYsO6ixXb6xPlaYE44VmNDNAuKHBbtbA==";

    // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
    public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAuCrx1yLDKU116gPmUShljVMv+/J1WZBn9F5b+f3IfkTHrF5qZPwFCqRXf60UYOXnxZrjEjFnnzHIQUFKbk6+5MVGEn0tR/lRaRXzbwnW7fFVETRoE6cwbpU/t3fHtmHGmeV+HDXBRbRqw5BuPpYoRrOx6J65YcCC5iyXjAxi1oS27eu87G8NI7oZ4InqJUk9ujuhysanJVsBfi9itlf0AljcIsMnuAF6e7oj2IlC0Hko8FOsDAvLtmqiLq3DoMmhimoO0oCVTjup0Kz04bdQLyh3pO+I12H7WUeNvB0OSNBqSBFkaWHtdOF7VxAvBk6DwKJXF8cWbhlNALIKgQaK7wIDAQAB";

    // 签名方式
    public static string sign_type = "RSA2";

    // 编码格式
    public static string charset = "UTF-8";
}