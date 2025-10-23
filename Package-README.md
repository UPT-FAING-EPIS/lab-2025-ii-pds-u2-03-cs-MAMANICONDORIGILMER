# NuGet Packages

This repository publishes the following NuGet packages to GitHub Packages:

## Available Packages

### Payment.Domain
**Package ID:** `Payment.Domain`

Domain layer for payment processing with Strategy pattern implementation.

**Features:**
- Strategy pattern for different payment methods
- Credit card, debit card, and cash payment strategies
- Type-safe payment processing

**Installation:**
```bash
dotnet add package Payment.Domain --source https://nuget.pkg.github.com/{owner}/index.json
```

**Usage:**
```csharp
using Payment.Domain;

// Create payment context
var paymentContext = new PaymentContext();

// Set payment strategy
paymentContext.SetPaymentStrategy(new CreditCardPaymentStrategy());

// Process payment
bool success = paymentContext.Pay(100.00);
```

### ATM.Domain
**Package ID:** `ATM.Domain`

Domain layer for ATM operations with Command pattern implementation.

**Features:**
- Command pattern for ATM operations
- Deposit and withdrawal commands
- Account management

**Installation:**
```bash
dotnet add package ATM.Domain --source https://nuget.pkg.github.com/{owner}/index.json
```

**Usage:**
```csharp
using ATM.Domain;

// Create ATM instance
var atm = new ATM();

// Execute deposit command
var depositCommand = new DepositCommand(account, 100.00);
atm.ExecuteCommand(depositCommand);

// Execute withdrawal command
var withdrawCommand = new WithdrawCommand(account, 50.00);
atm.ExecuteCommand(withdrawCommand);
```

## GitHub Actions Workflow

The `package_nuget.yml` workflow provides:

### Automated Testing
- Unit test execution with coverage reporting
- Test result reporting with detailed summaries
- Code coverage analysis with Codecov integration

### Code Quality Analysis
- SonarCloud static code analysis
- Security vulnerability scanning
- Code smell detection
- Technical debt assessment

### Package Publishing
- Automated NuGet package creation
- Version management with build numbers
- Publishing to GitHub Packages
- Release notes generation

## Configuration

### Required Secrets

Add the following secrets to your GitHub repository:

1. **SONAR_TOKEN**: SonarCloud authentication token
   - Go to SonarCloud → Account → Security → Generate Token
   - Copy the token and add it as `SONAR_TOKEN` in repository secrets

### Required Packages Source

Add GitHub Packages as a NuGet source:

```bash
# Add GitHub Packages source
dotnet nuget add source --name github "https://nuget.pkg.github.com/{owner}/index.json"

# Update NuGet config for authentication
dotnet nuget update source github --username {username} --password {personal-access-token}
```

### Personal Access Token Setup

1. Go to GitHub Settings → Developer settings → Personal access tokens
2. Generate new token with `read:packages` scope
3. Use this token for NuGet authentication

## Workflow Triggers

The workflow runs on:
- Push to `main` or `develop` branches (for paths in Payment/ or ATM/ directories)
- Pull requests to `main` branch (for changes in Payment/ or ATM/ directories)

## Build Artifacts

- **Test Reports**: Available in Actions run logs
- **Coverage Reports**: Uploaded to Codecov
- **NuGet Packages**: Available as downloadable artifacts for 30 days
- **SonarCloud Results**: Available on SonarCloud dashboard

## Quality Gates

The workflow includes several quality checks:
- All unit tests must pass
- Code coverage thresholds (configurable in Codecov)
- SonarCloud quality gate must pass
- No critical security vulnerabilities

## Troubleshooting

### Package Not Found
- Ensure GitHub Packages source is properly configured
- Check that packages were successfully published in Actions logs
- Verify authentication credentials

### Test Failures
- Check test output in Actions logs
- Review code coverage reports on Codecov
- Examine SonarCloud analysis results

### Publishing Issues
- Verify GITHUB_TOKEN permissions
- Check that workflow runs on correct branch
- Ensure no conflicting package versions