# Version Release Workflow

This document explains how to create versioned releases of your NuGet packages and publish them to GitHub Releases.

## Workflow Overview

The `release_version.yml` workflow creates formal version releases with the following features:

### Triggers
- **Version Tags**: Automatically triggered when pushing tags like `v1.0.0`
- **Manual Dispatch**: Can be triggered manually from GitHub Actions UI

### Release Process
1. **Quality Assurance**: Runs all tests and code analysis
2. **Package Creation**: Builds NuGet packages with proper versioning
3. **GitHub Packages**: Publishes to GitHub Packages (optional)
4. **GitHub Release**: Creates release with packages as downloadable assets

## Creating a Release

### Method 1: Version Tags (Recommended)

1. **Update Version Numbers**
   ```bash
   # Update project versions if needed
   # Edit Payment.Domain.csproj and ATM.Domain.csproj
   ```

2. **Create Git Tag**
   ```bash
   # Create and push version tag
   git tag v1.0.0
   git push origin v1.0.0
   ```

3. **Workflow Triggers**
   - The workflow automatically runs
   - Creates release with tag name as version
   - Publishes packages to GitHub Packages

### Method 2: Manual Release

1. **Go to Actions Tab**
   - Navigate to GitHub repository → Actions

2. **Run Workflow**
   - Find "Create Version Release" workflow
   - Click "Run workflow"
   - Enter version tag (e.g., `v1.0.0`)

3. **Monitor Progress**
   - Watch workflow execution
   - Check for any failures
   - Review generated release

## Version Naming Convention

Follow semantic versioning: `vMAJOR.MINOR.PATCH`

### Examples
- `v1.0.0` - First stable release
- `v1.1.0` - Minor feature release
- `v1.1.1` - Patch/bug fix release
- `v2.0.0` - Major version with breaking changes

### Pre-release Versions
- `v1.0.0-alpha.1` - Alpha release
- `v1.0.0-beta.1` - Beta release
- `v1.0.0-rc.1` - Release candidate

## Release Contents

Each release includes:

### GitHub Release Assets
- **Payment.Domain.x.x.x.nupkg** - Main package
- **Payment.Domain.x.x.x.snupkg** - Symbols package
- **ATM.Domain.x.x.x.nupkg** - Main package
- **ATM.Domain.x.x.x.snupkg** - Symbols package

### Release Information
- **Release Notes**: Auto-generated from commits
- **Package Versions**: Listed in description
- **Installation Instructions**: Included in notes

## Quality Gates

Before creating a release, the workflow ensures:

✅ **All Tests Pass**
- Unit tests for both projects
- Integration tests if any
- Test coverage requirements

✅ **Code Quality**
- SonarCloud analysis passes
- No critical issues
- Code coverage thresholds met

✅ **Package Integrity**
- Packages build successfully
- Metadata is correct
- Dependencies are resolved

## Package Information

### Payment.Domain Package
- **ID**: `Payment.Domain`
- **Description**: Domain layer for payment processing with Strategy pattern
- **Features**:
  - Strategy pattern implementation
  - Credit card, debit card, cash payments
  - Type-safe payment processing

### ATM.Domain Package
- **ID**: `ATM.Domain`
- **Description**: Domain layer for ATM operations with Command pattern
- **Features**:
  - Command pattern implementation
  - Deposit and withdrawal operations
  - Account management

## Installation from Release

### Download Packages
1. Go to GitHub Releases page
2. Find your version (e.g., v1.0.0)
3. Download `.nupkg` files

### Manual Installation
```bash
# Install specific package
dotnet add package Payment.Domain --source ./local-packages --version 1.0.0
```

### Using GitHub Packages
```bash
# Add GitHub Packages source (one time setup)
dotnet nuget add source --name github "https://nuget.pkg.github.com/{owner}/index.json"

# Install packages
dotnet add package Payment.Domain --version 1.0.0
dotnet add package ATM.Domain --version 1.0.0
```

## Troubleshooting

### Release Creation Fails

**Problem**: Workflow fails during test execution
**Solution**:
- Check test output in workflow logs
- Fix failing tests locally
- Ensure all dependencies are available

**Problem**: Package creation fails
**Solution**:
- Verify project files are valid
- Check NuGet package configuration
- Ensure all dependencies are available

**Problem**: GitHub Release not created
**Solution**:
- Check workflow permissions
- Verify GITHUB_TOKEN has release permissions
- Ensure no existing release with same tag

### Package Installation Issues

**Problem**: Package not found in GitHub Packages
**Solution**:
- Check if workflow completed successfully
- Verify package was published
- Ensure correct authentication

**Problem**: Version conflicts
**Solution**:
- Clear NuGet cache: `dotnet nuget locals all --clear`
- Remove and re-add GitHub Packages source
- Check package version in release notes

## Best Practices

### Version Management
- Use semantic versioning consistently
- Tag releases after successful testing
- Avoid force-pushing version tags

### Release Notes
- Write meaningful commit messages
- Use conventional commit format
- Include breaking changes prominently

### Package Quality
- Run tests before creating releases
- Review SonarCloud results
- Test package installation locally

## Workflow Configuration

### Required Secrets
- **SONAR_TOKEN**: SonarCloud authentication (optional for releases)

### Branch Protection
- Consider protecting main branch
- Require status checks before merging
- Enable required reviewers

## Support

For issues with the release workflow:
1. Check Actions logs for detailed error messages
2. Review SonarCloud dashboard for code quality issues
3. Verify package configuration in project files
4. Test package creation locally before releasing

## Examples

### Creating a Patch Release
```bash
git tag v1.0.1
git push origin v1.0.1
```

### Creating a Feature Release
```bash
git tag v1.1.0
git push origin v1.1.0
```

### Manual Release for Hotfix
1. Go to Actions → "Create Version Release"
2. Enter version tag: `v1.0.2-hotfix.1`
3. Click "Run workflow"

This workflow ensures consistent, high-quality releases with proper testing and documentation.