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


