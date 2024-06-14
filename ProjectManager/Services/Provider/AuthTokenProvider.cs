using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ProjectManager.Models.Auth;

namespace ProjectManager.Services.Provider;

public class AuthTokenProvider(
	IDataProtectionProvider dataProtectionProvider,
	IOptions<DataProtectionTokenProviderOptions> options,
	ILogger<DataProtectorTokenProvider<User>> logger)
	: DataProtectorTokenProvider<User>(dataProtectionProvider, options, logger);