FROM microsoft/aspnetcore:1.1
ARG source
WORKDIR /app
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "r0-core.service.dll"]
