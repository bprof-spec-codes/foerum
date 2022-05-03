const Migrations = artifacts.require("Migrations");
const Blog = artifacts.require("NikCoin");


module.exports = function (deployer) {
  deployer.deploy(Migrations);
  deployer.deploy(NikCoin);
};
