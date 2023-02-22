﻿public class User
{
    public string username;
    public string pwd;
    public string nom;
    public string prenom;
    public string annee;
    public string classe;

    public User() {
    }
    public User(string username, string pwd) {
        this.username = username;
        this.pwd = pwd;
        this.nom = "";
        this.prenom = "";
        this.classe = "";
    }
    public User(string username, string pwd,string nom,string prenom,string annee,string classe) {
        this.username = username;
        this.pwd = pwd;
        this.nom = nom;
        this.prenom = prenom;
        this.annee = annee;
        this.classe = classe;
    }
    
}