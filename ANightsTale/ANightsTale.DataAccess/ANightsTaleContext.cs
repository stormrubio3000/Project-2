using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ANightsTale.DataAccess
{
    public partial class ANightsTaleContext : DbContext
    {
        public ANightsTaleContext()
        {
        }

        public ANightsTaleContext(DbContextOptions<ANightsTaleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abilities> Abilities { get; set; }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<CharAbilities> CharAbilities { get; set; }
        public virtual DbSet<CharFeats> CharFeats { get; set; }
        public virtual DbSet<CharStats> CharStats { get; set; }
        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Feats> Feats { get; set; }
        public virtual DbSet<Info> Info { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<UserCampaign> UserCampaign { get; set; }
        public virtual DbSet<Users> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Abilities>(entity =>
            {
                entity.HasKey(e => e.AbilityId)
                    .HasName("PK__Abilitie__88B2505FA46FB128");

                entity.ToTable("Abilities", "Game");

                entity.Property(e => e.AbilityId).HasColumnName("AbilityID");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.RequiredLv).HasColumnName("RequiredLV");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign", "Game");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Campaign__737584F6CF4C1722")
                    .IsUnique();

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<CharAbilities>(entity =>
            {
                entity.HasKey(e => new { e.CharacterId, e.AbilityId });

                entity.ToTable("CharAbilities", "Game");

                entity.Property(e => e.CharacterId).HasColumnName("CharacterID");

                entity.Property(e => e.AbilityId).HasColumnName("AbilityID");

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.CharAbilities)
                    .HasForeignKey(d => d.AbilityId)
                    .HasConstraintName("FK_CharAb_To_Abilities");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharAbilities)
                    .HasForeignKey(d => d.CharacterId)
                    .HasConstraintName("FK_CharAb_To_Character");
            });

            modelBuilder.Entity<CharFeats>(entity =>
            {
                entity.HasKey(e => new { e.CharacterId, e.FeatId });

                entity.ToTable("CharFeats", "Game");

                entity.Property(e => e.CharacterId).HasColumnName("CharacterID");

                entity.Property(e => e.FeatId).HasColumnName("FeatID");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharFeats)
                    .HasForeignKey(d => d.CharacterId)
                    .HasConstraintName("FK_CharFeat_To_Character");

                entity.HasOne(d => d.Feat)
                    .WithMany(p => p.CharFeats)
                    .HasForeignKey(d => d.FeatId)
                    .HasConstraintName("FK_CharFeat_To_Feats");
            });

            modelBuilder.Entity<CharStats>(entity =>
            {
                entity.ToTable("CharStats", "Game");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ac).HasColumnName("AC");

                entity.Property(e => e.ChaMod).HasColumnName("CHA_Mod");

                entity.Property(e => e.ChaSave).HasColumnName("CHA_Save");

                entity.Property(e => e.CharacterId).HasColumnName("CharacterID");

                entity.Property(e => e.ConMod).HasColumnName("CON_Mod");

                entity.Property(e => e.ConSave).HasColumnName("CON_Save");

                entity.Property(e => e.DexMod).HasColumnName("DEX_Mod");

                entity.Property(e => e.DexSave).HasColumnName("DEX_Save");

                entity.Property(e => e.Hp).HasColumnName("HP");

                entity.Property(e => e.IntMod).HasColumnName("INT_Mod");

                entity.Property(e => e.IntSave).HasColumnName("INT_Save");

                entity.Property(e => e.Pb).HasColumnName("PB");

                entity.Property(e => e.StrMod).HasColumnName("STR_Mod");

                entity.Property(e => e.StrSave).HasColumnName("STR_Save");

                entity.Property(e => e.WisMod).HasColumnName("WIS_Mod");

                entity.Property(e => e.WisSave).HasColumnName("WIS_Save");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharStats)
                    .HasForeignKey(d => d.CharacterId)
                    .HasConstraintName("Stats_To_Char");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("Character", "Game");

                entity.Property(e => e.CharacterId).HasColumnName("CharacterID");

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.Cha).HasColumnName("CHA");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Experience)
                    .HasColumnName("experience")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Level).HasDefaultValueSql("((1))");

                entity.Property(e => e.MaxHp).HasColumnName("MaxHP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.RaceId).HasColumnName("RaceID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_Char_to_C");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("Fk_Char_to_Class");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.RaceId)
                    .HasConstraintName("FK_Char_to_Race");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("Fk_Char_to_User");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class", "Game");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Hd).HasColumnName("HD");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Feats>(entity =>
            {
                entity.HasKey(e => e.FeatId)
                    .HasName("PK__Feats__D53F25EE5D7A12D5");

                entity.ToTable("Feats", "Game");

                entity.Property(e => e.FeatId).HasColumnName("FeatID");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.RequiredLv).HasColumnName("RequiredLV");
            });

            modelBuilder.Entity<Info>(entity =>
            {
                entity.ToTable("Info", "Game");

                entity.Property(e => e.InfoId).HasColumnName("InfoID");

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Info)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_I_to_C");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.CharacterId, e.ItemId })
                    .HasName("PK__Inventor__D25C227E0D3C9564");

                entity.ToTable("Inventory", "Game");

                entity.Property(e => e.CharacterId).HasColumnName("CharacterID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ToggleE).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.CharacterId)
                    .HasConstraintName("FK_I_to_Char");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("Fk_I_to_Item");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item", "Game");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Ac).HasColumnName("AC");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.ToTable("Race", "Game");

                entity.Property(e => e.RaceId).HasColumnName("RaceID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserCampaign>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CampaignId })
                    .HasName("PK__userCamp__947D247B17341963");

                entity.ToTable("userCampaign", "Game");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.UserCampaign)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_UC_to_C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCampaign)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UC_to_U");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Game");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Users__536C85E40252BA71")
                    .IsUnique();

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Permission).HasDefaultValueSql("((0))");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }
    }
}
