/*
 Navicat Premium Dump SQL

 Source Server         : localhost-mysql
 Source Server Type    : MySQL
 Source Server Version : 80042 (8.0.42)
 Source Host           : localhost:3306
 Source Schema         : maiziwpf

 Target Server Type    : MySQL
 Target Server Version : 80042 (8.0.42)
 File Encoding         : 65001

 Date: 21/02/2026 22:27:23
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sys_config
-- ----------------------------
DROP TABLE IF EXISTS `sys_config`;
CREATE TABLE `sys_config`  (
  `config_id` bigint NOT NULL AUTO_INCREMENT,
  `config_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `config_key` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `config_value` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `config_type` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_time` datetime(3) NOT NULL,
  `update_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `update_time` datetime(3) NOT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`config_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 100 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_config
-- ----------------------------
INSERT INTO `sys_config` VALUES (1, '主框架页-默认皮肤样式名称', 'sys.index.skinName', 'skin-blue', 'Y', 'admin', '2026-02-21 22:15:06.000', '', '0001-01-01 00:00:00.000', '蓝色 skin-blue、绿色 skin-green、紫色 skin-purple、红色 skin-red、黄色 skin-yellow', '0');
INSERT INTO `sys_config` VALUES (2, '用户管理-账号初始密码', 'sys.user.initPassword', '123456', 'Y', 'admin', '2026-02-21 22:15:06.000', '', '0001-01-01 00:00:00.000', '初始化密码 123456', '0');
INSERT INTO `sys_config` VALUES (3, '主框架页-侧边栏主题', 'sys.index.sideTheme', 'theme-dark', 'Y', 'admin', '2026-02-21 22:15:06.000', '', '0001-01-01 00:00:00.000', '深色主题theme-dark，浅色主题theme-light', '0');
INSERT INTO `sys_config` VALUES (4, '账号自助-验证码开关', 'sys.account.captchaEnabled', 'true', 'Y', 'admin', '2026-02-21 22:15:06.000', '', '0001-01-01 00:00:00.000', '是否开启验证码功能（true开启，false关闭）', '0');
INSERT INTO `sys_config` VALUES (5, '账号自助-是否开启用户注册功能', 'sys.account.registerUser', 'false', 'Y', 'admin', '2026-02-21 22:15:06.000', '', '0001-01-01 00:00:00.000', '是否开启注册用户功能（true开启，false关闭）', '0');
INSERT INTO `sys_config` VALUES (6, '用户登录-黑名单列表', 'sys.login.blackIPList', '', 'Y', 'admin', '2026-02-21 22:15:06.000', '', '0001-01-01 00:00:00.000', '设置登录IP黑名单限制，多个匹配项以;分隔，支持匹配（*通配、网段）', '0');
INSERT INTO `sys_config` VALUES (7, '用户管理-初始密码修改策略', 'sys.account.initPasswordModify', '1', 'Y', 'admin', '2026-02-21 22:15:06.000', '', '0001-01-01 00:00:00.000', '0：初始密码修改策略关闭，没有任何提示，1：提醒用户，如果未修改初始密码，则在登录时就会提醒修改密码对话框', '0');
INSERT INTO `sys_config` VALUES (8, '用户管理-账号密码更新周期', 'sys.account.passwordValidateDays', '0', 'Y', 'admin', '2026-02-21 22:15:06.000', '', '0001-01-01 00:00:00.000', '密码更新周期（填写数字，数据初始化值为0不限制，若修改必须为大于0小于365的正整数），如果超过这个周期登录系统时，则在登录时就会提醒修改密码对话框', '0');

-- ----------------------------
-- Table structure for sys_dept
-- ----------------------------
DROP TABLE IF EXISTS `sys_dept`;
CREATE TABLE `sys_dept`  (
  `dept_id` bigint NOT NULL AUTO_INCREMENT,
  `parent_id` bigint NOT NULL,
  `ancestors` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `dept_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `order_num` int NOT NULL,
  `leader` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `phone` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `status` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_time` datetime(3) NOT NULL,
  `update_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `update_time` datetime(3) NOT NULL,
  PRIMARY KEY (`dept_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 200 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_dept
-- ----------------------------
INSERT INTO `sys_dept` VALUES (100, 0, '0', '若依科技', 0, '若依', '15888888888', 'ry@qq.com', '0', '0', 'admin', '2026-01-26 16:14:42.000', '', '0001-01-01 00:00:00.000');
INSERT INTO `sys_dept` VALUES (101, 100, '0,100', '深圳总公司', 1, '若依', '15888888888', 'ry@qq.com', '0', '0', 'admin', '2026-01-26 16:14:42.000', '', '0001-01-01 00:00:00.000');
INSERT INTO `sys_dept` VALUES (102, 100, '0,100', '长沙分公司', 2, '若依', '15888888888', 'ry@qq.com', '0', '0', 'admin', '2026-01-26 16:14:42.000', '', '0001-01-01 00:00:00.000');
INSERT INTO `sys_dept` VALUES (103, 101, '0,100,101', '研发部门', 1, '若依', '15888888888', 'ry@qq.com', '0', '0', 'admin', '2026-01-26 16:14:42.000', '', '0001-01-01 00:00:00.000');
INSERT INTO `sys_dept` VALUES (104, 101, '0,100,101', '市场部门', 2, '若依', '15888888888', 'ry@qq.com', '0', '0', 'admin', '2026-01-26 16:14:42.000', '', '0001-01-01 00:00:00.000');
INSERT INTO `sys_dept` VALUES (105, 101, '0,100,101', '测试部门', 3, '若依', '15888888888', 'ry@qq.com', '0', '0', 'admin', '2026-01-26 16:14:42.000', '', '0001-01-01 00:00:00.000');
INSERT INTO `sys_dept` VALUES (106, 101, '0,100,101', '财务部门', 4, '若依', '15888888888', 'ry@qq.com', '0', '0', 'admin', '2026-01-26 16:14:42.000', '', '0001-01-01 00:00:00.000');
INSERT INTO `sys_dept` VALUES (107, 101, '0,100,101', '运维部门', 5, '若依', '15888888888', 'ry@qq.com', '0', '0', 'admin', '2026-01-26 16:14:42.000', '', '0001-01-01 00:00:00.000');
INSERT INTO `sys_dept` VALUES (108, 102, '0,100,102', '市场部门', 1, '若依', '15888888888', 'ry@qq.com', '0', '0', 'admin', '2026-01-26 16:14:42.000', '', '0001-01-01 00:00:00.000');
INSERT INTO `sys_dept` VALUES (109, 102, '0,100,102', '财务部门', 2, '若依', '15888888888', 'ry@qq.com', '0', '0', 'admin', '2026-01-26 16:14:42.000', '', '0001-01-01 00:00:00.000');

-- ----------------------------
-- Table structure for sys_dict_data
-- ----------------------------
DROP TABLE IF EXISTS `sys_dict_data`;
CREATE TABLE `sys_dict_data`  (
  `dict_code` bigint NOT NULL AUTO_INCREMENT,
  `dict_sort` int NOT NULL,
  `dict_label` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `dict_value` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `dict_type` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `is_default` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `status` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_time` datetime(3) NOT NULL,
  `update_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `update_time` datetime(3) NOT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`dict_code`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 100 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_dict_data
-- ----------------------------
INSERT INTO `sys_dict_data` VALUES (1, 1, '男', '0', 'sys_user_sex', 'Y', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '性别男', NULL);
INSERT INTO `sys_dict_data` VALUES (2, 2, '女', '1', 'sys_user_sex', 'N', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '性别女', NULL);
INSERT INTO `sys_dict_data` VALUES (3, 3, '未知', '2', 'sys_user_sex', 'N', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '性别未知', NULL);
INSERT INTO `sys_dict_data` VALUES (4, 1, '显示', '0', 'sys_show_hide', 'Y', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '显示菜单', NULL);
INSERT INTO `sys_dict_data` VALUES (5, 2, '隐藏', '1', 'sys_show_hide', 'N', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '隐藏菜单', NULL);
INSERT INTO `sys_dict_data` VALUES (6, 1, '正常', '0', 'sys_normal_disable', 'Y', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '正常状态', NULL);
INSERT INTO `sys_dict_data` VALUES (7, 2, '停用', '1', 'sys_normal_disable', 'N', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '停用状态', NULL);
INSERT INTO `sys_dict_data` VALUES (8, 1, '正常', '0', 'sys_job_status', 'Y', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '正常状态', NULL);
INSERT INTO `sys_dict_data` VALUES (9, 2, '暂停', '1', 'sys_job_status', 'N', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '停用状态', NULL);
INSERT INTO `sys_dict_data` VALUES (10, 1, '默认', 'DEFAULT', 'sys_job_group', 'Y', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '默认分组', NULL);
INSERT INTO `sys_dict_data` VALUES (11, 2, '系统', 'SYSTEM', 'sys_job_group', 'N', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '系统分组', NULL);
INSERT INTO `sys_dict_data` VALUES (12, 1, '是', 'Y', 'sys_yes_no', 'Y', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '系统默认是', NULL);
INSERT INTO `sys_dict_data` VALUES (13, 2, '否', 'N', 'sys_yes_no', 'N', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '系统默认否', NULL);
INSERT INTO `sys_dict_data` VALUES (14, 1, '通知', '1', 'sys_notice_type', 'Y', '0', 'admin', '2026-02-12 03:21:52.000', '', '0001-01-01 00:00:00.000', '通知', NULL);
INSERT INTO `sys_dict_data` VALUES (15, 2, '公告', '2', 'sys_notice_type', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '公告', NULL);
INSERT INTO `sys_dict_data` VALUES (16, 1, '正常', '0', 'sys_notice_status', 'Y', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '正常状态', NULL);
INSERT INTO `sys_dict_data` VALUES (17, 2, '关闭', '1', 'sys_notice_status', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '关闭状态', NULL);
INSERT INTO `sys_dict_data` VALUES (18, 99, '其他', '0', 'sys_oper_type', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '其他操作', NULL);
INSERT INTO `sys_dict_data` VALUES (19, 1, '新增', '1', 'sys_oper_type', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '新增操作', NULL);
INSERT INTO `sys_dict_data` VALUES (20, 2, '修改', '2', 'sys_oper_type', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '修改操作', NULL);
INSERT INTO `sys_dict_data` VALUES (21, 3, '删除', '3', 'sys_oper_type', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '删除操作', NULL);
INSERT INTO `sys_dict_data` VALUES (22, 4, '授权', '4', 'sys_oper_type', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '授权操作', NULL);
INSERT INTO `sys_dict_data` VALUES (23, 5, '导出', '5', 'sys_oper_type', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '导出操作', NULL);
INSERT INTO `sys_dict_data` VALUES (24, 6, '导入', '6', 'sys_oper_type', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '导入操作', NULL);
INSERT INTO `sys_dict_data` VALUES (25, 7, '强退', '7', 'sys_oper_type', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '强退操作', NULL);
INSERT INTO `sys_dict_data` VALUES (26, 8, '生成代码', '8', 'sys_oper_type', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '生成操作', NULL);
INSERT INTO `sys_dict_data` VALUES (27, 9, '清空数据', '9', 'sys_oper_type', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '清空操作', NULL);
INSERT INTO `sys_dict_data` VALUES (28, 1, '成功', '0', 'sys_common_status', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '正常状态', NULL);
INSERT INTO `sys_dict_data` VALUES (29, 2, '失败', '1', 'sys_common_status', 'N', '0', 'admin', '2026-02-12 03:21:53.000', '', '0001-01-01 00:00:00.000', '停用状态', NULL);

-- ----------------------------
-- Table structure for sys_dict_type
-- ----------------------------
DROP TABLE IF EXISTS `sys_dict_type`;
CREATE TABLE `sys_dict_type`  (
  `dict_id` bigint NOT NULL AUTO_INCREMENT,
  `dict_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `dict_type` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `status` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_time` datetime(3) NOT NULL,
  `update_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `update_time` datetime(3) NOT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`dict_id`) USING BTREE,
  UNIQUE INDEX `dict_type`(`dict_type` ASC) USING BTREE,
  UNIQUE INDEX `uk_dictType`(`dict_type` ASC) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 100 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_dict_type
-- ----------------------------
INSERT INTO `sys_dict_type` VALUES (1, '用户性别', 'sys_user_sex', '0', 'admin', '2026-02-21 22:14:33.000', '', '0001-01-01 00:00:00.000', '用户性别列表', '0');
INSERT INTO `sys_dict_type` VALUES (2, '菜单状态', 'sys_show_hide', '0', 'admin', '2026-02-21 22:14:33.000', '', '0001-01-01 00:00:00.000', '菜单状态列表', '0');
INSERT INTO `sys_dict_type` VALUES (3, '系统开关', 'sys_normal_disable', '0', 'admin', '2026-02-21 22:14:33.000', '', '0001-01-01 00:00:00.000', '系统开关列表', '0');
INSERT INTO `sys_dict_type` VALUES (4, '任务状态', 'sys_job_status', '0', 'admin', '2026-02-21 22:14:33.000', '', '0001-01-01 00:00:00.000', '任务状态列表', '0');
INSERT INTO `sys_dict_type` VALUES (5, '任务分组', 'sys_job_group', '0', 'admin', '2026-02-21 22:14:33.000', '', '0001-01-01 00:00:00.000', '任务分组列表', '0');
INSERT INTO `sys_dict_type` VALUES (6, '系统是否', 'sys_yes_no', '0', 'admin', '2026-02-21 22:14:33.000', '', '0001-01-01 00:00:00.000', '系统是否列表', '0');
INSERT INTO `sys_dict_type` VALUES (7, '通知类型', 'sys_notice_type', '0', 'admin', '2026-02-21 22:14:33.000', '', '0001-01-01 00:00:00.000', '通知类型列表', '0');
INSERT INTO `sys_dict_type` VALUES (8, '通知状态', 'sys_notice_status', '0', 'admin', '2026-02-21 22:14:33.000', '', '0001-01-01 00:00:00.000', '通知状态列表', '0');
INSERT INTO `sys_dict_type` VALUES (9, '操作类型', 'sys_oper_type', '0', 'admin', '2026-02-21 22:14:33.000', '', '0001-01-01 00:00:00.000', '操作类型列表', '0');
INSERT INTO `sys_dict_type` VALUES (10, '系统状态', 'sys_common_status', '0', 'admin', '2026-02-21 22:14:33.000', '', '0001-01-01 00:00:00.000', '登录状态列表', '0');

-- ----------------------------
-- Table structure for sys_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_menu`;
CREATE TABLE `sys_menu`  (
  `menu_id` bigint NOT NULL AUTO_INCREMENT,
  `menu_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `parent_id` bigint NOT NULL,
  `order_num` int NOT NULL,
  `menu_type` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `visible` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `status` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `perms` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `icon` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_time` datetime(3) NOT NULL,
  `update_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `update_time` datetime(3) NOT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `level` int NOT NULL,
  `component` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `query` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`menu_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2000 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_menu
-- ----------------------------
INSERT INTO `sys_menu` VALUES (1, '系统管理', 0, 1, 'M', '0', '0', '', 'WrenchCogOutline', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '系统管理目录', '0', 1, NULL, NULL);
INSERT INTO `sys_menu` VALUES (2, '首页', 0, 0, 'C', '0', '0', '', 'Home', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '首页', '0', 1, 'DashboardView', NULL);
INSERT INTO `sys_menu` VALUES (100, '用户管理', 1, 1, 'C', '0', '0', 'system:user:list', 'Account', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '用户管理菜单', '0', 2, 'UserListView', NULL);
INSERT INTO `sys_menu` VALUES (101, '角色管理', 1, 2, 'C', '0', '0', 'system:role:list', 'AccountSwitch', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '角色管理菜单', '0', 2, 'RoleListView', NULL);
INSERT INTO `sys_menu` VALUES (102, '菜单管理', 1, 3, 'C', '0', '0', 'system:menu:list', 'FileTreeOutline', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '菜单管理菜单', '0', 2, 'MenuListView', NULL);
INSERT INTO `sys_menu` VALUES (103, '部门管理', 1, 4, 'C', '0', '0', 'system:dept:list', 'FamilyTree', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '部门管理菜单', '0', 2, 'DeptListView', NULL);
INSERT INTO `sys_menu` VALUES (104, '岗位管理', 1, 5, 'C', '0', '0', 'system:post:list', 'Post', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '岗位管理菜单', '0', 2, 'PostListView', NULL);
INSERT INTO `sys_menu` VALUES (105, '字典管理', 1, 6, 'C', '0', '0', 'system:dict:list', 'BookAlphabet', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '字典管理菜单', '0', 2, 'DictListView', NULL);
INSERT INTO `sys_menu` VALUES (106, '参数设置', 1, 7, 'C', '0', '0', 'system:config:list', 'ReceiptTextEditOutline', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '参数设置菜单', '0', 2, 'ConfigListView', NULL);
INSERT INTO `sys_menu` VALUES (1000, '用户查询', 100, 1, 'F', '0', '0', 'system:user:query', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1001, '用户新增', 100, 2, 'F', '0', '0', 'system:user:add', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1002, '用户修改', 100, 3, 'F', '0', '0', 'system:user:edit', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1003, '用户删除', 100, 4, 'F', '0', '0', 'system:user:remove', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1004, '用户导出', 100, 5, 'F', '0', '0', 'system:user:export', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1005, '用户导入', 100, 6, 'F', '0', '0', 'system:user:import', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1006, '重置密码', 100, 7, 'F', '0', '0', 'system:user:resetPwd', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1007, '角色查询', 101, 1, 'F', '0', '0', 'system:role:query', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1008, '角色新增', 101, 2, 'F', '0', '0', 'system:role:add', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1009, '角色修改', 101, 3, 'F', '0', '0', 'system:role:edit', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1010, '角色删除', 101, 4, 'F', '0', '0', 'system:role:remove', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1011, '角色导出', 101, 5, 'F', '0', '0', 'system:role:export', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1012, '菜单查询', 102, 1, 'F', '0', '0', 'system:menu:query', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1013, '菜单新增', 102, 2, 'F', '0', '0', 'system:menu:add', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1014, '菜单修改', 102, 3, 'F', '0', '0', 'system:menu:edit', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1015, '菜单删除', 102, 4, 'F', '0', '0', 'system:menu:remove', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1016, '部门查询', 103, 1, 'F', '0', '0', 'system:dept:query', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1017, '部门新增', 103, 2, 'F', '0', '0', 'system:dept:add', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1018, '部门修改', 103, 3, 'F', '0', '0', 'system:dept:edit', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1019, '部门删除', 103, 4, 'F', '0', '0', 'system:dept:remove', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1020, '岗位查询', 104, 1, 'F', '0', '0', 'system:post:query', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1021, '岗位新增', 104, 2, 'F', '0', '0', 'system:post:add', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1022, '岗位修改', 104, 3, 'F', '0', '0', 'system:post:edit', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1023, '岗位删除', 104, 4, 'F', '0', '0', 'system:post:remove', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1024, '岗位导出', 104, 5, 'F', '0', '0', 'system:post:export', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1025, '字典查询', 105, 1, 'F', '0', '0', 'system:dict:query', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1026, '字典新增', 105, 2, 'F', '0', '0', 'system:dict:add', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1027, '字典修改', 105, 3, 'F', '0', '0', 'system:dict:edit', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1028, '字典删除', 105, 4, 'F', '0', '0', 'system:dict:remove', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1029, '字典导出', 105, 5, 'F', '0', '0', 'system:dict:export', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1030, '参数查询', 106, 1, 'F', '0', '0', 'system:config:query', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1031, '参数新增', 106, 2, 'F', '0', '0', 'system:config:add', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1032, '参数修改', 106, 3, 'F', '0', '0', 'system:config:edit', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1033, '参数删除', 106, 4, 'F', '0', '0', 'system:config:remove', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);
INSERT INTO `sys_menu` VALUES (1034, '参数导出', 106, 5, 'F', '0', '0', 'system:config:export', '#', 'admin', '2026-01-26 16:22:59.000', '', '0001-01-01 00:00:00.000', '', '0', 0, NULL, NULL);

-- ----------------------------
-- Table structure for sys_post
-- ----------------------------
DROP TABLE IF EXISTS `sys_post`;
CREATE TABLE `sys_post`  (
  `post_id` bigint NOT NULL AUTO_INCREMENT,
  `post_code` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `post_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `post_sort` int NOT NULL,
  `status` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_time` datetime(3) NOT NULL,
  `update_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `update_time` datetime(3) NOT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`post_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_post
-- ----------------------------
INSERT INTO `sys_post` VALUES (1, 'ceo', '董事长', 1, '0', 'admin', '2026-01-26 16:19:41.000', '', '0001-01-01 00:00:00.000', '', '0');
INSERT INTO `sys_post` VALUES (2, 'se', '项目经理', 2, '0', 'admin', '2026-01-26 16:19:41.000', '', '0001-01-01 00:00:00.000', '', '0');
INSERT INTO `sys_post` VALUES (3, 'hr', '人力资源', 3, '0', 'admin', '2026-01-26 16:19:41.000', '', '0001-01-01 00:00:00.000', '', '0');
INSERT INTO `sys_post` VALUES (4, 'user', '普通员工', 4, '0', 'admin', '2026-01-26 16:19:41.000', '', '0001-01-01 00:00:00.000', '', '0');

-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role`  (
  `role_id` bigint NOT NULL AUTO_INCREMENT,
  `role_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `role_key` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `role_sort` int NOT NULL,
  `data_scope` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `status` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_time` datetime(3) NOT NULL,
  `update_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `update_time` datetime(3) NOT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`role_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 100 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES (1, '超级管理员', 'admin', 1, '1', '0', '0', 'admin', '2026-01-26 16:20:00.000', '', '0001-01-01 00:00:00.000', '超级管理员');
INSERT INTO `sys_role` VALUES (2, '普通角色', 'common', 2, '2', '0', '0', 'admin', '2026-01-26 16:20:00.000', '', '0001-01-01 00:00:00.000', '普通角色');

-- ----------------------------
-- Table structure for sys_role_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_role_menu`;
CREATE TABLE `sys_role_menu`  (
  `role_id` bigint NOT NULL COMMENT '角色ID',
  `menu_id` bigint NOT NULL COMMENT '菜单ID',
  PRIMARY KEY (`role_id`, `menu_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '角色和菜单关联表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_role_menu
-- ----------------------------
INSERT INTO `sys_role_menu` VALUES (2, 1);
INSERT INTO `sys_role_menu` VALUES (2, 2);
INSERT INTO `sys_role_menu` VALUES (2, 100);
INSERT INTO `sys_role_menu` VALUES (2, 101);
INSERT INTO `sys_role_menu` VALUES (2, 102);
INSERT INTO `sys_role_menu` VALUES (2, 103);
INSERT INTO `sys_role_menu` VALUES (2, 104);
INSERT INTO `sys_role_menu` VALUES (2, 105);
INSERT INTO `sys_role_menu` VALUES (2, 106);
INSERT INTO `sys_role_menu` VALUES (2, 1000);
INSERT INTO `sys_role_menu` VALUES (2, 1001);
INSERT INTO `sys_role_menu` VALUES (2, 1002);
INSERT INTO `sys_role_menu` VALUES (2, 1003);
INSERT INTO `sys_role_menu` VALUES (2, 1004);
INSERT INTO `sys_role_menu` VALUES (2, 1005);
INSERT INTO `sys_role_menu` VALUES (2, 1006);
INSERT INTO `sys_role_menu` VALUES (2, 1007);
INSERT INTO `sys_role_menu` VALUES (2, 1008);
INSERT INTO `sys_role_menu` VALUES (2, 1009);
INSERT INTO `sys_role_menu` VALUES (2, 1010);
INSERT INTO `sys_role_menu` VALUES (2, 1011);
INSERT INTO `sys_role_menu` VALUES (2, 1012);
INSERT INTO `sys_role_menu` VALUES (2, 1013);
INSERT INTO `sys_role_menu` VALUES (2, 1014);
INSERT INTO `sys_role_menu` VALUES (2, 1015);
INSERT INTO `sys_role_menu` VALUES (2, 1016);
INSERT INTO `sys_role_menu` VALUES (2, 1017);
INSERT INTO `sys_role_menu` VALUES (2, 1018);
INSERT INTO `sys_role_menu` VALUES (2, 1019);
INSERT INTO `sys_role_menu` VALUES (2, 1020);
INSERT INTO `sys_role_menu` VALUES (2, 1021);
INSERT INTO `sys_role_menu` VALUES (2, 1022);
INSERT INTO `sys_role_menu` VALUES (2, 1023);
INSERT INTO `sys_role_menu` VALUES (2, 1024);
INSERT INTO `sys_role_menu` VALUES (2, 1025);
INSERT INTO `sys_role_menu` VALUES (2, 1026);
INSERT INTO `sys_role_menu` VALUES (2, 1027);
INSERT INTO `sys_role_menu` VALUES (2, 1028);
INSERT INTO `sys_role_menu` VALUES (2, 1029);
INSERT INTO `sys_role_menu` VALUES (2, 1030);
INSERT INTO `sys_role_menu` VALUES (2, 1031);
INSERT INTO `sys_role_menu` VALUES (2, 1032);
INSERT INTO `sys_role_menu` VALUES (2, 1033);
INSERT INTO `sys_role_menu` VALUES (2, 1034);

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user`  (
  `user_id` bigint NOT NULL AUTO_INCREMENT,
  `user_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `nick_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `user_type` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `phonenumber` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `sex` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `avatar` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `password` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `status` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `login_ip` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `login_date` datetime(3) NOT NULL,
  `pwd_update_date` datetime(3) NOT NULL,
  `create_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_time` datetime(3) NOT NULL,
  `update_by` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `update_time` datetime(3) NOT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`user_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 100 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES (1, 'admin', '若依', '00', 'ry@163.com', '15888888888', '1', '', '$2a$10$7JB720yubVSZvUI0rEqK/.VqGOZTH.ulu33dHOiBE8ByOhJIrdAu2', '0', '0', '127.0.0.1', '2026-01-26 16:17:12.000', '2026-01-26 16:17:12.000', 'admin', '2026-01-26 16:17:12.000', '', '0001-01-01 00:00:00.000', '管理员');
INSERT INTO `sys_user` VALUES (2, 'ry', '若依', '00', 'ry@qq.com', '15666666666', '1', '', '$2a$10$7JB720yubVSZvUI0rEqK/.VqGOZTH.ulu33dHOiBE8ByOhJIrdAu2', '0', '0', '127.0.0.1', '2026-01-26 16:17:12.000', '2026-01-26 16:17:12.000', 'admin', '2026-01-26 16:17:12.000', '', '0001-01-01 00:00:00.000', '测试员');

-- ----------------------------
-- Table structure for sys_user_dept
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_dept`;
CREATE TABLE `sys_user_dept`  (
  `user_id` bigint NOT NULL,
  `dept_id` bigint NOT NULL,
  PRIMARY KEY (`user_id`, `dept_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_user_dept
-- ----------------------------
INSERT INTO `sys_user_dept` VALUES (2, 100);
INSERT INTO `sys_user_dept` VALUES (2, 101);
INSERT INTO `sys_user_dept` VALUES (2, 105);

-- ----------------------------
-- Table structure for sys_user_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_menu`;
CREATE TABLE `sys_user_menu`  (
  `user_id` bigint NOT NULL COMMENT '用户ID',
  `menu_id` bigint NOT NULL COMMENT '菜单ID',
  PRIMARY KEY (`user_id`, `menu_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '用户和菜单关联表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_user_menu
-- ----------------------------

-- ----------------------------
-- Table structure for sys_user_post
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_post`;
CREATE TABLE `sys_user_post`  (
  `user_id` bigint NOT NULL,
  `post_id` bigint NOT NULL,
  PRIMARY KEY (`user_id`, `post_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_user_post
-- ----------------------------
INSERT INTO `sys_user_post` VALUES (1, 1);
INSERT INTO `sys_user_post` VALUES (2, 2);

-- ----------------------------
-- Table structure for sys_user_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_role`;
CREATE TABLE `sys_user_role`  (
  `user_id` bigint NOT NULL,
  `role_id` bigint NOT NULL,
  PRIMARY KEY (`user_id`, `role_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_user_role
-- ----------------------------
INSERT INTO `sys_user_role` VALUES (1, 1);
INSERT INTO `sys_user_role` VALUES (2, 2);

SET FOREIGN_KEY_CHECKS = 1;
