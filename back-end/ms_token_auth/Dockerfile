FROM openjdk:11
ADD target/token-auth.jar token-auth.jar
EXPOSE 10500
ENTRYPOINT ["java", "-jar", "token-auth.jar"]