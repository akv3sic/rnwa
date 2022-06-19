
public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
{
    // Initialization.
    string usernameVal = context.UserName;
    string passwordVal = context.Password;
    var user = this.databaseManager.LoginByUsernamePassword(usernameVal, passwordVal).ToList();

    // Verification.
    if (user == null || user.Count() <= 0)
    {
        // Settings.
        context.SetError("invalid_grant", "The user name or password is incorrect.");

        // Retuen info.
        return;
    }

    // Initialization.
    var claims = new List<Claim>();
    var userInfo = user.FirstOrDefault();

    // Setting
    claims.Add(new Claim(ClaimTypes.Name, userInfo.username));

    // Setting Claim Identities for OAUTH 2 protocol.
    ClaimsIdentity oAuthClaimIdentity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
    ClaimsIdentity cookiesClaimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

    // Setting user authentication.
    AuthenticationProperties properties = CreateProperties(userInfo.username);
    AuthenticationTicket ticket = new AuthenticationTicket(oAuthClaimIdentity, properties);

    // Grant access to authorize user.
    context.Validated(ticket);
    context.Request.Context.Authentication.SignIn(cookiesClaimIdentity);
}
