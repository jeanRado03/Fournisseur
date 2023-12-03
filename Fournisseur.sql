create table article(
  idarticle varchar(50) primary key,
  designation varchar(50),
  nature varchar(50)
);

create table personne(
  idpersonne varchar(50) primary key,
  nom varchar(55),
  prenom varchar(65),
  dateNaissance date,
  genre varchar(12),
  mail varchar(200),
  phone varchar(40)
);

create table fournisseurs(
  idfournisseur varchar(50) primary key,
  idpersonne varchar(50) references personne (idpersonne),
  idmagasin varchar(50) references magasin (idmagasin),
  mdp varchar(103)
);

create table mouvement(
  idmouvement varchar(50) primary key,
  dateMouvement date,
  idarticle varchar(50) references article (idarticle),
  quantite double precision,
  unite varchar(12),
  montantUnitaire double precision,
  tva double precision,
  idmagasin varchar(50) references magasin (idmagasin),
  type varchar(12)
);
