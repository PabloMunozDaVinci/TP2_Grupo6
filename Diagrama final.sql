-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- Link to schema: https://app.quickdatabasediagrams.com/#/d/dTXdBo
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.

-- Modify this code to update the DB schema diagram.
-- To reset the sample schema, replace everything with

SET XACT_ABORT ON

BEGIN TRANSACTION QUICKDBD

CREATE TABLE [Usuario] (
    [UsuarioID] int  NOT NULL ,
    [DNI] int  NOT NULL ,
    [Nombre] string  NOT NULL ,
    [Apellido] string  NOT NULL ,
    [Mail] string  NOT NULL ,
    [Password] string  NOT NULL ,
    [esADMIN] bool  NOT NULL ,
    [IntentosFallidos] int  NOT NULL ,
    [Bloqueado] bool  NOT NULL ,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED (
        [UsuarioID] ASC
    )
)

CREATE TABLE [Amigo] (
    [UsuarioID] int  NOT NULL ,
    [AmigoID] int  NOT NULL 
)

CREATE TABLE [Post] (
    [PostID] int  NOT NULL ,
    [UsuarioID] int  NOT NULL ,
    [ComentarioID] int  NOT NULL ,
    [Contenido] string  NOT NULL ,
    [Fecha] date  NOT NULL ,
    CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED (
        [PostID] ASC
    )
)

CREATE TABLE [Reaccion] (
    [ReaccionID] int  NOT NULL ,
    [Tipo] Enum  NOT NULL ,
    [PostID] int  NOT NULL ,
    [UsuarioID] int  NOT NULL ,
    CONSTRAINT [PK_Reaccion] PRIMARY KEY CLUSTERED (
        [ReaccionID] ASC
    )
)

CREATE TABLE [Comentario] (
    [ComentarioID] int  NOT NULL ,
    [PostID] int  NOT NULL ,
    [Usuario] money  NOT NULL ,
    [Contenido] string  NOT NULL ,
    [Fecha] date  NOT NULL ,
    CONSTRAINT [PK_Comentario] PRIMARY KEY CLUSTERED (
        [ComentarioID] ASC
    )
)

CREATE TABLE [Tag] (
    [TagID] int  NOT NULL ,
    [Palabra] string  NULL ,
    CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED (
        [TagID] ASC
    )
)

CREATE TABLE [Tag_Post] (
    [TagID] int  NOT NULL ,
    [PostID] int  NOT NULL ,
    [UltimaActualizacion] date  NOT NULL 
)

ALTER TABLE [Amigo] WITH CHECK ADD CONSTRAINT [FK_Amigo_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [Usuario] ([UsuarioID])

ALTER TABLE [Amigo] CHECK CONSTRAINT [FK_Amigo_UsuarioID]

ALTER TABLE [Amigo] WITH CHECK ADD CONSTRAINT [FK_Amigo_AmigoID] FOREIGN KEY([AmigoID])
REFERENCES [Usuario] ([UsuarioID])

ALTER TABLE [Amigo] CHECK CONSTRAINT [FK_Amigo_AmigoID]

ALTER TABLE [Post] WITH CHECK ADD CONSTRAINT [FK_Post_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [Usuario] ([UsuarioID])

ALTER TABLE [Post] CHECK CONSTRAINT [FK_Post_UsuarioID]

ALTER TABLE [Post] WITH CHECK ADD CONSTRAINT [FK_Post_ComentarioID] FOREIGN KEY([ComentarioID])
REFERENCES [Comentario] ([ComentarioID])

ALTER TABLE [Post] CHECK CONSTRAINT [FK_Post_ComentarioID]

ALTER TABLE [Reaccion] WITH CHECK ADD CONSTRAINT [FK_Reaccion_PostID] FOREIGN KEY([PostID])
REFERENCES [Post] ([PostID])

ALTER TABLE [Reaccion] CHECK CONSTRAINT [FK_Reaccion_PostID]

ALTER TABLE [Reaccion] WITH CHECK ADD CONSTRAINT [FK_Reaccion_UsuarioID] FOREIGN KEY([UsuarioID])
REFERENCES [Usuario] ([UsuarioID])

ALTER TABLE [Reaccion] CHECK CONSTRAINT [FK_Reaccion_UsuarioID]

ALTER TABLE [Comentario] WITH CHECK ADD CONSTRAINT [FK_Comentario_PostID] FOREIGN KEY([PostID])
REFERENCES [Post] ([PostID])

ALTER TABLE [Comentario] CHECK CONSTRAINT [FK_Comentario_PostID]

ALTER TABLE [Tag_Post] WITH CHECK ADD CONSTRAINT [FK_Tag_Post_TagID] FOREIGN KEY([TagID])
REFERENCES [Tag] ([TagID])

ALTER TABLE [Tag_Post] CHECK CONSTRAINT [FK_Tag_Post_TagID]

ALTER TABLE [Tag_Post] WITH CHECK ADD CONSTRAINT [FK_Tag_Post_PostID] FOREIGN KEY([PostID])
REFERENCES [Post] ([PostID])

ALTER TABLE [Tag_Post] CHECK CONSTRAINT [FK_Tag_Post_PostID]

COMMIT TRANSACTION QUICKDBD