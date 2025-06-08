namespace ams.service.repositories;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.FullName).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
        builder.Property(u => u.PasswordHash).HasMaxLength(256).IsRequired();
        builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
        builder.Property(u => u.IsActive).HasDefaultValue(true);

        // Relationships
        builder.HasMany(u => u.LoginHistories)
               .WithOne(lh => lh.User)
               .HasForeignKey(lh => lh.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.UserRoles)
               .WithOne(ur => ur.User)
               .HasForeignKey(ur => ur.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}


internal class LoginHistoryConfiguration : IEntityTypeConfiguration<LoginHistory>
{
    public void Configure(EntityTypeBuilder<LoginHistory> builder)
    {
        // Primary Key
        builder.HasKey(lh => lh.HistoryId);

        // Foreign Key Relation
        builder.HasOne(lh => lh.User)
               .WithMany(u => u.LoginHistories)
               .HasForeignKey(lh => lh.UserId)
               .OnDelete(DeleteBehavior.Cascade); // Ensures cascade delete when a user is removed

        // Properties
        builder.Property(lh => lh.LoginTime)
               .HasDefaultValueSql("GETDATE()");

        builder.Property(lh => lh.IPAddress)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(lh => lh.DeviceInfo)
               .HasMaxLength(255)
               .IsRequired(false);
    }
}

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.RoleId);
        builder.Property(r => r.RoleName).HasMaxLength(50).IsRequired();

        // Relationships
        builder.HasMany(r => r.UserRoles)
               .WithOne(ur => ur.Role)
               .HasForeignKey(ur => ur.RoleId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.RolePermissions)
               .WithOne(rp => rp.Role)
               .HasForeignKey(rp => rp.RoleId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        // Primary Key
        builder.HasKey(ur => ur.UserRoleId);

        // Foreign Key Relation - User to UserRoles
        builder.HasOne(ur => ur.User)
               .WithMany(u => u.UserRoles)
               .HasForeignKey(ur => ur.UserId)
               .OnDelete(DeleteBehavior.Cascade); // Deletes UserRoles if User is removed

        // Foreign Key Relation - Role to UserRoles
        builder.HasOne(ur => ur.Role)
               .WithMany(r => r.UserRoles)
               .HasForeignKey(ur => ur.RoleId)
               .OnDelete(DeleteBehavior.Cascade); // Deletes UserRoles if Role is removed

        // Ensuring Unique User-Role Assignments
        builder.HasIndex(ur => new { ur.UserId, ur.RoleId }).IsUnique();
    }
}

internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(p => p.PermissionId);
        builder.Property(p => p.PermissionName).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Category).HasMaxLength(50).IsRequired();

        // Relationships
        builder.HasMany(p => p.RolePermissions)
               .WithOne(rp => rp.Permission)
               .HasForeignKey(rp => rp.PermissionId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

internal class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        // Primary Key
        builder.HasKey(rp => rp.RolePermissionId);

        // Foreign Key Relation - Role to RolePermissions
        builder.HasOne(rp => rp.Role)
               .WithMany(r => r.RolePermissions)
               .HasForeignKey(rp => rp.RoleId)
               .OnDelete(DeleteBehavior.Cascade); // Deletes related RolePermissions if Role is removed

        // Foreign Key Relation - Permission to RolePermissions
        builder.HasOne(rp => rp.Permission)
               .WithMany(p => p.RolePermissions)
               .HasForeignKey(rp => rp.PermissionId)
               .OnDelete(DeleteBehavior.Cascade); // Deletes related RolePermissions if Permission is removed

        // Ensuring Unique Role-Permission Assignments
        builder.HasIndex(rp => new { rp.RoleId, rp.PermissionId }).IsUnique();
    }
}
