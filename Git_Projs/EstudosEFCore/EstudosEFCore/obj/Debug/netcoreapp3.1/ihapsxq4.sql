IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Motoristas] (
    [MotoristaId] nvarchar(450) NOT NULL,
    [Nome] nvarchar(max) NULL,
    [CNH] nvarchar(max) NULL,
    [ValidadeCNH] datetime2 NOT NULL,
    [Ativo] bit NULL,
    CONSTRAINT [PK_Motoristas] PRIMARY KEY ([MotoristaId])
);

GO

CREATE TABLE [Veiculos] (
    [VeiculoId] nvarchar(450) NOT NULL,
    [Modelo] nvarchar(max) NULL,
    [Placa] nvarchar(max) NULL,
    [Ano] int NOT NULL,
    CONSTRAINT [PK_Veiculos] PRIMARY KEY ([VeiculoId])
);

GO

CREATE TABLE [MotoristasVeiculos] (
    [MotoristaVeiculoId] nvarchar(450) NOT NULL,
    [VeiculoId] nvarchar(450) NULL,
    [MotoristaId] nvarchar(450) NULL,
    CONSTRAINT [PK_MotoristasVeiculos] PRIMARY KEY ([MotoristaVeiculoId]),
    CONSTRAINT [FK_MotoristasVeiculos_Motoristas_MotoristaId] FOREIGN KEY ([MotoristaId]) REFERENCES [Motoristas] ([MotoristaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MotoristasVeiculos_Veiculos_VeiculoId] FOREIGN KEY ([VeiculoId]) REFERENCES [Veiculos] ([VeiculoId]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_MotoristasVeiculos_MotoristaId] ON [MotoristasVeiculos] ([MotoristaId]);

GO

CREATE INDEX [IX_MotoristasVeiculos_VeiculoId] ON [MotoristasVeiculos] ([VeiculoId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220901154332_InitialCreate', N'3.1.28');

GO

