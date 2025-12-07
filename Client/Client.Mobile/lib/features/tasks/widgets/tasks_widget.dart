import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/features/leaves/widgets/build_app_bar_row.dart';
import 'package:athr_hr/features/leaves/widgets/build_leaves_types_row.dart';
import 'package:athr_hr/features/leaves/widgets/tabs_row.dart';
import 'package:athr_hr/features/tasks/widgets/build_card_tasks.dart';
import 'package:athr_hr/features/tasks/widgets/cards_to_show_list.dart';
import 'package:athr_hr/features/tasks/widgets/tasks_model.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class TasksWidget extends StatefulWidget {
  const TasksWidget({super.key});

  @override
  State<TasksWidget> createState() => _TasksWidgetState();
}

class _TasksWidgetState extends State<TasksWidget> {
  late TaskModel taskImplementation;
  late TaskModel taskCompleted;
  int progressInProgress = 50;
  int progressInComplete = 100;
  int selectedTabIndex = 0;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();

    if (!mounted) return;

    taskImplementation = TaskModel(
      title: context.translate(LangKeys.authenticationUnit),
      subtitle: context.translate(LangKeys.oauthIntegration),
      progress: 50,
      date: context.translate(LangKeys.date20251115),
      onProgressChanged: (newValue) {
        setState(() {
          taskImplementation.progress = newValue;
        });
      },
    );

    taskCompleted = TaskModel(
      title: context.translate(LangKeys.authenticationUnit),
      subtitle: context.translate(LangKeys.oauthIntegration),
      progress: 100,
      date: context.translate(LangKeys.date20251115),
      onProgressChanged: (newValue) {
        setState(() {
          taskCompleted.progress = newValue;
        });
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: Padding(
          padding: EdgeInsets.all(8.sp),
          child: SingleChildScrollView(
            child: Column(
              children: [
                SizedBox(height: 20.h),
                BuildRow(
                  titleKey: context.translate(LangKeys.tasks),
                  image: Assets.imagesAddtask,
                  onPressed: () {
                    Navigator.pushNamed(context, AppRoutes.createTaskView);
                  },
                ),
                SizedBox(height: 20.h),
                BuildCardTasksSelectable(),
                SizedBox(height: 24.h),
                BuildCustomRow(
                  text: context.translate(LangKeys.tasks),
                  imagePath: Assets.imagesLeavetype,
                  onTap: () {},
                ),
                SizedBox(height: 16.h),
                CustomTabsRow(
                  tabs: [
                    "${context.translate(LangKeys.all)} (${context.translate(LangKeys.allTasksValue)})",
                    "${context.translate(LangKeys.inProgress)} (${context.translate(LangKeys.approvedValue)})",
                    "${context.translate(LangKeys.completed)} (${context.translate(LangKeys.pendingValue)})",
                  ],
                  onTabSelected: (index) {
                    setState(() {
                      selectedTabIndex = index;
                    });
                  },
                ),
                SizedBox(height: 24.h),
                ...TaskCardsHelper.cardsToShow(
                  context: context,
                  selectedTabIndex: selectedTabIndex,
                  progressInProgress: progressInProgress,
                  progressInComplete: progressInComplete,
                  onProgressInProgressChanged: (value) {
                    setState(() {
                      progressInProgress = value;
                    });
                  },
                  onProgressInCompleteChanged: (value) {
                    setState(() {
                      progressInComplete = value;
                    });
                  },
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
