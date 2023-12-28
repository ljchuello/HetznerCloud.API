# 🌐 Hetzner Cloud API

![Hetzner](https://github.com/ljchuello/HetznerCloud.API/assets/5316348/4e1b4486-5cfe-4470-9055-c8ac3f965249)


## **Welcome to the Hetzner Cloud API documentation** 🚀

This project is your complete guide to exploring and utilizing the Hetzner Cloud API. Here, you'll find everything you need to integrate your projects with one of the most powerful and efficient cloud platforms.

**Key Features:**

* **Quick Start:** Begin with simple examples to connect and use the API. 🖥️
* **Detailed API Reference:** Each endpoint is explained with code examples, making it easy even for beginners. 📚
* **Use Cases:** Discover how other developers are leveraging the API in real-world scenarios. 💡
* **Security and Best Practices:** Learn to use the API securely and efficiently. 🔐
* **Support and Community:** Join our community and get help when you need it. 👥

**Who is This GitBook For?**

* **System and Web Developers:** If you program in C#, Angular, or any other language, you'll find useful resources here.
* **IT and Network Professionals:** Tips for securing and optimizing your cloud projects.

**Start Now!** Navigate the chapters, dive into the example codes, and take your cloud projects to the next level. We're here to help you every step of the way! 🌟

***

### To see all the features and functionality, visit [<mark style="color:green;">the Wiki</mark>](https://ljchuello.gitbook.io/hetznercloud.api/)

***

## 🔗 Compatibility

This library is developed in **.NET Standard 2.0** and is compatible with all **.NET, .NET Core and .NET Framework**, it can also be used in Console projects, Web API, Class Library and even with Blazor WASM .

| .NET implementation | Version support                               |
| ------------------- | --------------------------------------------- |
| .NET and .NET Core  | 2.0, 2.1, 2.2, 3.0, 3.1, 5.0, 6.0, 7.0, 8.0   |
| .NET Framework      | 4.6.1 2, 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1 |

***

## 🔧 Installation

To install you must go to Nuget package manager and search for **HetznerCloud.API** and then install.

[**NuGet Package**](https://www.nuget.org/packages/HetznerCloud.API/)

```powershell
PM> dotnet add package HetznerCloud.API
```

***

## :heavy\_check\_mark: Implemented functionality

:heavy\_check\_mark: - Available on API, implemented\
:x: - Available on API, not implemented\
:heavy\_minus\_sign: - Not available on API

|                   |        Get all       |        Get one       |        Create        |        Update        |        Delete        |        Actions       |
| ----------------- | :------------------: | :------------------: | :------------------: | :------------------: | :------------------: | :------------------: |
| Actions           | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: |
| Datacenters       | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: |
| Firewalls         | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_minus\_sign: |
| Firewalls Actions | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_check\_mark: |
| Images            | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: |
| Locations         | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: |
| Networks          | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_minus\_sign: |
| Networks Actions  | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_check\_mark: |
| Servers           | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_minus\_sign: |
| Server Types      | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: |
| SSH Keys          | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_minus\_sign: |
| Volumes           | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_check\_mark: | :heavy\_minus\_sign: |
| Volumes Actions   | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_minus\_sign: | :heavy\_check\_mark: |
