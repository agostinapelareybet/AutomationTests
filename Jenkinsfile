pipeline {
    agent any

    tools {
        dotnet 'dotnet-sdk-7.0'
    }

    stages {
        stage('Checkout') {
            steps {
                // Clone repository from Git
                git 'https://github.com/agostinapelareybet/AutomationTests.git'
            }
        }

        stage('Build') {
            steps {
                // Build the project using .NET
                bat 'dotnet build'
            }
        }

        stage('Test') {
            steps {
                // Run tests with NUnit
                bat 'dotnet test'
            }
        }
    }
    
    post {
        always {
            // Clean up after execution
            cleanWs()
        }
    }
}
