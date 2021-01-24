# syntax=docker/dockerfile:experimental
FROM nschultz/fantasy-baseball-common-models:0.5.3 AS build
COPY . /app
ENV MAIN_PROJ=FantasyBaseball.BhqStatsService \
    SONAR_KEY=fantasy-baseball-bhq-stats
RUN --mount=type=cache,id=sonarqube,target=/root/.sonar/cache ./build.sh

FROM nschultz/base-csharp-runner:0.5.2
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "FantasyBaseball.BhqStatsService.dll"]