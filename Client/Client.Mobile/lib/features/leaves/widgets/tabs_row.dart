import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CustomTabsRow extends StatefulWidget {
  final List<String> tabs;
  final int initialSelectedIndex;
  final ValueChanged<int>? onTabSelected;

  const CustomTabsRow({
    super.key,
    required this.tabs,
    this.initialSelectedIndex = 0,
    this.onTabSelected,
  });

  @override
  State<CustomTabsRow> createState() => _CustomTabsRowState();
}

class _CustomTabsRowState extends State<CustomTabsRow> {
  late int selectedIndex;

  @override
  void initState() {
    super.initState();
    selectedIndex = widget.initialSelectedIndex;
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 8.w, vertical: 4.h),
      decoration: BoxDecoration(
        border: Border.all(color: const Color(0xFFF4F4F4)),
        borderRadius: BorderRadius.circular(100.sp),
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: List.generate(
          widget.tabs.length,
              (index) => GestureDetector(
            onTap: () {
              setState(() {
                selectedIndex = index;
              });
              if (widget.onTabSelected != null) {
                widget.onTabSelected!(index);
              }
            },
            child: _tabItem(widget.tabs[index], index == selectedIndex),
          ),
        ),
      ),
    );
  }

  Widget _tabItem(String title, bool selected) {
    return Container(
      height: selected ? 41.h : null,
      padding: EdgeInsets.symmetric(vertical: 10.h, horizontal: 18.w),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20.sp),
        gradient: selected
            ? const LinearGradient(
          colors: [Color(0xFF1BABB6), Color(0xCC005157)],
        )
            : null,
        color: selected ? null : Colors.transparent,
      ),
      alignment: Alignment.center,
      child: FittedBox(
        fit: BoxFit.scaleDown,
        child: Text(
          title,
          style: TextStyle(
            fontSize: 12.sp,
            fontWeight: selected ? FontWeight.w700 : FontWeight.w600,
            color: selected ? Colors.white : Colors.black,
          ),
        ),
      ),
    );
  }
}
