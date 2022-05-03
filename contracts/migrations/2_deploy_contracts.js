const NikCoin = artifacts.require("./NikCoin.sol");

module.exports = function (deployer) {
  deployer.deploy(NikCoin);
};
